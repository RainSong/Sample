using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CSScriptLibrary;
using LabelPrinter.Common;
using LabelPrinter.Domain.Models;

namespace LabelPrinter.Domain
{
    public class DataHelper
    {
        internal SqlHelper sqlHelper = null;

        internal DataHelper() 
        {
            this.sqlHelper = new SqlHelper();
        }

        internal LabelStyle GetLabelStyle(int carSeqn, int carItemSeqn) 
        {
            var sqlCommandText = @" IF OBJECT_ID('tempdb..#TMP_SCI') IS NOT NULL
                                    BEGIN
	                                    DROP TABLE #TMP_SCI
                                    END

                                    SELECT	 CI2.StyleID
		                                    ,CI2.CarSeqn
		                                    ,CI2.CarItemSeqn 
                                    INTO #TMP_SCI
                                    FROM		dbo.TB_SYS_LABEL_STYLE_CARITEM	AS CI	WITH(NOLOCK)
                                    LEFT JOIN	dbo.TB_SYS_LABEL_STYLE			AS S	WITH(NOLOCK)	ON CI.StyleID = S.ID
                                    LEFT JOIN	dbo.TB_SYS_LABEL_STYLE_CARITEM	AS CI2	WITH(NOLOCK)	ON S.ID = CI2.StyleID
                                    WHERE CI.Usable = 1
                                    AND CI2.Usable = 1
                                    AND S.Usabel = 1 
                                    AND CI.CarSeqn = @CarSeqn
                                    AND CI.CarItemSeqn = @CarItemSeqn

                                    SELECT   S.ID
                                            ,S.Width
		                                    ,S.Height
		                                    ,S.LabelType
                                    FROM dbo.TB_SYS_LABEL_STYLE          AS S WITH(NOLOCK) 
                                    WHERE ID IN (SELECT StyleID FROM #TMP_SCI)

                                    SELECT *
                                    FROM #TMP_SCI";
            var param = new
            {
                CarSeqn = carSeqn,
                CarItemSeqn = carItemSeqn
            };
            IEnumerable< LabelStyle> labelStyles = null;
            IEnumerable<LabelStyleCarItem> labelCarItems = null;
            LabelStyle labelStyle = null;
            sqlHelper.Query(out labelStyles, out labelCarItems, sqlCommandText, param);
            if (labelStyles != null)
            {
                labelStyle = labelStyles.FirstOrDefault();
                labelStyle.CarItems = labelCarItems;
            }

            IEnumerable<LabelStyleItem> styleItems = null;
            if (labelStyle != null)
            {
                styleItems = GetItemsByStyle(labelStyle.ID);
                var styleItemProperties = GetItemPropertiesByStyle(labelStyle.ID);
                var scripts = GetScriptsByStyle(labelStyle.ID);
                foreach (var item in styleItems) 
                {
                    item.Properties = styleItemProperties.Where(o => o.ItemID == item.ID);

                    if (item.ValueType == LabelStyleItemValueType.Compute) 
                    {
                        var script = scripts.FirstOrDefault(o => o.ID.ToString() == item.Data);
                        if (script != null) 
                        {
                            item.Func = CSScript.CreateFunc<string>(script.ScriptContent);
                        }
                    }

                }
                labelStyle.Items = styleItems;
            }
            return labelStyle;
        }

        internal IEnumerable<Script> GetScripts()
        {
            var sqlCmdText = @"SELECT   ID
		                                ,[Name]
		                                ,KeyCode
		                                ,ScriptContent
                                        ,Remark
                                FROM dbo.TB_SYS_SCRIPTS
                                WHERE Usable = 1";
            return sqlHelper.Query<Script>(sqlCmdText);
        }

        internal IEnumerable<LabelStyle> GetLabelStyles() 
        {
            var sqlCmdText = @"SELECT   ID
                                        ,Name
		                                ,Width
		                                ,Height
		                                ,LabelType
		                                ,Remark
                                FROM TB_SYS_LABEL_STYLE
                                WHERE Usabel = 1";
            return sqlHelper.Query<LabelStyle>(sqlCmdText);

        }

        internal IEnumerable<LabelStyleItem> GetItemsByStyle(int labelStyleId) 
        {
            var sqlCommandText = @"SELECT    ID
                                            ,StyleID
		                                    ,[Data]
		                                    ,ValueType
		                                    ,ItemType
                                            ,Remark
                                    FROM dbo.TB_SYS_LABEL_STYLE_ITEM WITH(NOLOCK) 
                                    WHERE Usable = 1 
                                    AND StyleID = @StyleID";
            var param = new
            {
                StyleID = labelStyleId
            };
            return sqlHelper.Query<LabelStyleItem>(sqlCommandText, param);
        }

        internal IEnumerable<LabelStyleItemProperty> GetItemPropertiesByStyle(int labelStyleId) 
        {
            var sqlCommandText = @"SELECT   ItemID
                                           , PropertyType
                                           , PropertyValue
                                           , ValueType AS PropertyValueType
                                   FROM dbo.TB_SYS_LABEL_STYLE_ITEM_PROPERTY WITH(NOLOCK)
                                   WHERE Usable = 1
                                   AND StyleID = @StyleID";
            var param = new
            {
                StyleID = labelStyleId
            };
            return sqlHelper.Query<LabelStyleItemProperty>(sqlCommandText, param);
        }

        internal IEnumerable<LabelStyleCarItem> GetStyleCarItemsByStyle(int labelStyleId) 
        {
            var sqlCmdText = @"SELECT	 S.ID
		                                ,C.CarSeqn
		                                ,C.CarName
		                                ,CI.CarItemSeqn
		                                ,CI.CarItemName
                                FROM dbo.TB_SYS_LABEL_STYLE_CARITEM	AS S WITH(NOLOCK)
                                LEFT JOIN dbo.TB_CAR				AS C WITH(NOLOCK) ON S.CarSeqn = C.CarSeqn
                                LEFT JOIN dbo.TB_CARITEM			AS CI WITH(NOLOCK) ON S.CarItemSeqn = CI.CarItemSeqn	
                                WHERE S.Usable = 1
                                AND S.StyleID = @StyleID";
            var param = new 
            {
                StyleID = labelStyleId
            };
            return sqlHelper.Query<LabelStyleCarItem>(sqlCmdText, param);
        }

        internal IEnumerable<LabelStyleItemProperty> GetPropertiesByItem(int itemId) 
        {
            var sqlCmdText = @"SELECT   ID
		                                ,ItemID
		                                ,PropertyType
		                                ,PropertyValue
                                        ,ValueType AS PropertyValueType
                                FROM dbo.TB_SYS_LABEL_STYLE_ITEM_PROPERTY	AS P WITH(NOLOCK)
                                WHERE Usable = 1
                                AND ItemID = @ItemID";
            var param = new
            {
                ItemID = itemId
            };
            return sqlHelper.Query<LabelStyleItemProperty>(sqlCmdText, param);
        }

        internal IEnumerable<Script> GetScriptsByStyle(int labelStyleId) 
        {
            var sqlCmdText = @"SELECT   S.ID
		                                ,KeyCode
		                                ,ScriptContent 
                                FROM		dbo.TB_SYS_LABEL_STYLE_ITEM		AS I WITH(NOLOCK) 
                                RIGHT JOIN	dbo.TB_SYS_SCRIPTS				AS S WITH(NOLOCK) ON I.Data = S.ID
                                WHERE StyleID = @StyleID
                                AND ValueType = 2
                                AND S.Usable = 1";
            var param = new
            {
                StyleID = labelStyleId
            };
            return this.sqlHelper.Query<Script>(sqlCmdText, param);
        }

        internal IEnumerable<Car> GetCars()
        {
            var sqlCmdText = @"SELECT	 CarSeqn
		                                ,CarName 
                                FROM TB_CAR AS Car 
                                ORDER BY DisplaySeq";
            return sqlHelper.Query<Car>(sqlCmdText, null);
        }

        internal IEnumerable<CarItem> GetCarItems()
        {
            var sqlCmdText = @"SELECT	 CarItemSeqn
		                                ,CarItemName
                                FROM TB_CARITEM AS CarItem
                                ORDER BY DisplaySeq";
            return sqlHelper.Query<CarItem>(sqlCmdText, null);
        }

        internal bool AddScript(Script script)
        {
            var sqlCmdText = @"INSERT INTO dbo.TB_SYS_SCRIPTS ( [Name]			,KeyCode		,ScriptContent		,Remark		,Usable		,Ver
								                                 ,CreateDate	,CreateUser		,ModifyDate			,ModifyUser)
						                                VALUES(  @Name			,@KeyCode		,@ScriptContent		,@Remark	,@Usable	,@Ver
								                                 ,GETDATE()		,'YGJ'			,GETDATE()			,'YGJ')";
            return sqlHelper.Execute(sqlCmdText, script) > 0;
        }

        internal bool UpdateScript(Script script)
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_SCRIPTS
                                SET [Name] = @Name
	                                ,KeyCode = @KeyCode
	                                ,ScriptContent = @ScriptContent
	                                ,Remark = @Remark
	                                ,ModifyDate = GETDATE()
	                                ,ModifyUser = 'YGJ'
                                WHERE ID = @ID";
            return sqlHelper.Execute(sqlCmdText, script) > 0;
        }

        internal bool DeleteLabelStyle(int styleId)
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_LABEL_STYLE SET Usabel = 0 WHERE ID = @StyleID;
                                UPDATE dbo.TB_SYS_LABEL_STYLE_CARITEM SET Usable = 0 WHERE StyleID = @StyleID;
                                UPDATE dbo.TB_SYS_LABEL_STYLE_ITEM SET Usable = 0 WHERE StyleID = @StyleID;
                                UPDATE dbo.TB_SYS_LABEL_STYLE_ITEM_PROPERTY SET Usable = 0 WHERE StyleID = @StyleID;
                                UPDATE S
                                SET S.Usable = 0 
                                FROM		dbo.TB_SYS_LABEL_STYLE_ITEM AS I
                                INNER JOIN	dbo.TB_SYS_SCRIPTS			AS S ON I.[Data] = S.ID
                                WHERE I.StyleID = 0
                                AND I.ValueType = 2
                                AND I.StyleID = @StyleID;";
            var param = new
            {
                StyleID = styleId
            };
            return sqlHelper.Execute(sqlCmdText, param) > 0;

        }

        internal bool AddLabelStyle(LabelStyle style)
        {
            var sqlCmdText = @"INSERT INTO dbo.TB_SYS_LABEL_STYLE(  Name        ,Width		,Height		    ,LabelType		
                                                                    ,Remark     ,Usabel		,CreateDate	    ,CreateUser		
                                                                    ,ModifyDate	,ModifyUser)
							                                VALUES(	 @Name      ,@Width		,@Height	    ,@LabelType		
                                                                     ,@Remark   ,1			,GETDATE()	    ,'YGJ'			
                                                                     ,GETDATE()	,'YGJ')";
            return sqlHelper.Execute(sqlCmdText, style) > 0;
        }

        internal bool UpdateLabelStyle(LabelStyle labelStyle)
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_LABEL_STYLE
                               SET Name = @Name
                                   , Width = @Width
                                   , Height = @Height
                                   , LabelType = @LabelType
                                   , Remark = @Remark
                                   , ModifyDate = GETDATE()
                                   , ModifyUser = 'YGJ'
                               WHERE ID = @ID";
            return sqlHelper.Execute(sqlCmdText, labelStyle) > 0;
        }

        internal bool DeleteLabelStleCarItem(int styleCarItemID) 
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_LABEL_STYLE_CARITEM SET Usable = 0 
                                WHERE ID = @StyleCarItemID";
            var param = new
            {
                StyleCarItemID = styleCarItemID
            };
            return sqlHelper.Execute(sqlCmdText, param) > 0;
        }

        internal bool AddLabelStyleCarItem(LabelStyleCarItem labelStyleCarItem) 
        {
            var sqlCmdText = @"INSERT INTO dbo.TB_SYS_LABEL_STYLE_CARITEM(	 StyleID	,CarSeqn	,CarItemSeqn	
											                                ,Usable		,CreateDate	,CreateUser		,ModifyDate	,ModifyUser)
									                                VALUES(	@StyleID	,@CarSeqn	,@CarItemSeqn	
											                                ,1			,GETDATE()	,'YGJ'			,GETDATE()	,'YGJ')";
            return sqlHelper.Execute(sqlCmdText, labelStyleCarItem) > 0;
        }

        internal bool UpdateLabelStyleCarItem(LabelStyleCarItem labelStyleCarItem)
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_LABEL_STYLE_CARITEM
                                SET CarSeqn = @CarSeqn
                                    , CarItemSeqn = @CarItemSeqn
                                WHERE ID = @ID";
            return sqlHelper.Execute(sqlCmdText, labelStyleCarItem) > 0;
        }

        internal bool AddLabelStyleItem(LabelStyleItem labelStyleItem)
        {
            var sqlCmdText = @"INSERT INTO dbo.TB_SYS_LABEL_STYLE_ITEM ( StyleID		,[Data]		,ValueType		,ItemType		,Usable		,Remark
										                                ,CreateDate	    ,CreateUser	,ModifyDate		,ModifyUser)
								                                   VALUES( @StyleID		,@Data		,@ValueType		,@ItemType		,1      	,@Remark
										                                  ,GETDATE()	,'YGJ'		,GETDATE()		,'YGJ');";
            if (labelStyleItem.ValueType == LabelStyleItemValueType.Compute)
            {
                sqlCmdText += @"DECLARE @ForeignID INT
                                SELECT @ForeignID = @@IDENTITY
                                INSERT INTO dbo.TB_SYS_SCRIPT_REFERENCE(ScriptID		,ForeignID		,ForeignType	,Usable
											                            ,CreateDate		,CreateUser		,ModifyDate		,ModifyUser)
									                            VALUES(	@ScriptID		,@ForeignID		,@ForeignType	,1
											                            ,GETDATE()		,'YGJ'			,GETDATE()		,'YGJ')";
            }
            var scriptId = 0;
            int.TryParse(labelStyleItem.Data, out scriptId);
            var param = new
            {
                StyleID = labelStyleItem.StyleID,
                Data = labelStyleItem.Data,
                ValueType = labelStyleItem.ValueType,
                ItemType = labelStyleItem.ItemType,
                Remark = labelStyleItem.Remark,
                ForeignType = ScriptRelatedType.LabelStyleItem,
                ScriptID = scriptId
            };
            return sqlHelper.Execute(sqlCmdText, param) > 0;
        }

        internal bool UpdateLabelStyleItem(LabelStyleItem labelStyleItem)
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_LABEL_STYLE_ITEM
                                SET [Data] = @Data
	                                ,ValueType = @ValueType
	                                ,ItemType = @ItemType
	                                ,Remark = @Remark
	                                ,ModifyDate = GETDATE()
	                                ,ModifyUser = 'YGJ'
                                WHERE ID = @ItemID;";
            if (labelStyleItem.ValueType == LabelStyleItemValueType.Compute) 
            {
                sqlCmdText += @"IF EXISTS (SELECT *
			                                FROM dbo.TB_SYS_SCRIPT_REFERENCE WITH(NOLOCK)
			                                WHERE ForeignID = @ForeignID
			                                AND ForeignType = @ForeignType
		                                  )
                                BEGIN
	                                UPDATE dbo.TB_SYS_SCRIPT_REFERENCE
	                                SET ScriptID = @ScriptID
		                                ,ModifyDate = GETDATE()
		                                ,ModifyUser = 'YGJ'
	                                WHERE ForeignID = @ForeignID
	                                AND ForeignType = @ForeignType
	                                AND ScriptID != @ScriptID
                                END
                                ELSE 
                                BEGIN
                                    DELETE FROM dbo.TB_SYS_SCRIPT_REFERENCE WHERE ForeignID = @ForeignID AND ForeignType = @ForeignType; 
	                                INSERT INTO dbo.TB_SYS_SCRIPT_REFERENCE(ScriptID		,ForeignID		,ForeignType	,Usable
											                                ,CreateDate		,CreateUser		,ModifyDate		,ModifyUser)
									                                VALUES(	@ScriptID		,@ForeignID		,@ForeignType	,1
											                                ,GETDATE()		,'YGJ'			,GETDATE()		,'YGJ')
                                END";
            }
            var scriptId = 0;
            int.TryParse(labelStyleItem.Data, out scriptId);
            var param = new
            {
                ItemID = labelStyleItem.ID,
                Data = labelStyleItem.Data,
                ValueType = labelStyleItem.ValueType,
                ItemType = labelStyleItem.ItemType,
                Remark = labelStyleItem.Remark,
                ForeignID = labelStyleItem.ID,
                ForeignType = ScriptRelatedType.LabelStyleItem,
                ScriptID = scriptId
            };
            return sqlHelper.Execute(sqlCmdText, param) > 0;
        }

        internal bool DeleteLabelStleItem(int itemId)
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_LABEL_STYLE_ITEM
                                SET Usable = 0
                                WHERE ID = @ID ";
            var param = new
            {
                ID = itemId
            };
            return sqlHelper.Execute(sqlCmdText, param) > 0;
        }

        internal bool AddLabelStyleItemProperty(LabelStyleItemProperty itemProperty)
        {
            var sqlCmdText = @"INSERT INTO dbo.TB_SYS_LABEL_STYLE_ITEM_PROPERTY(StyleID	,ItemID		,PropertyType	,PropertyValue	,ValueType
												 ,Usable	,Remark		,CreateDate		,CreateUser		,ModifyDate	,ModifyUser)
										  VALUES(@StyleID	,@ItemID	,@PropertyType	,@PropertyValue	,@ValueType
												 ,1			,@Remark	,GETDATE()		,'YGJ'			,GETDATE()	,'YGJ')";

            if (itemProperty.PropertyValueType == LabelStyleItemPropertyValueType.Compute)
            {
                sqlCmdText += @"DECLARE @ForeignID INT
                                SELECT @ForeignID = @@IDENTITY
                                INSERT INTO dbo.TB_SYS_SCRIPT_REFERENCE(ScriptID		,ForeignID		,ForeignType	,Usable
											                            ,CreateDate		,CreateUser		,ModifyDate		,ModifyUser)
									                            VALUES(	@ScriptID		,@ForeignID		,@ForeignType	,1
											                            ,GETDATE()		,'YGJ'			,GETDATE()		,'YGJ')";
            }
            var param = new
            {
                StyleID = itemProperty.StyleID,
                ItemID = itemProperty.ItemID,
                PropertyType = itemProperty.PropertyType,
                PropertyValue = itemProperty.PropertyValue,
                ValueType = itemProperty.PropertyValueType,
                Remark = itemProperty.Remark,
                ScriptID = itemProperty.PropertyValueType,
                ForeignType = ScriptRelatedType.LabelStyleItemProperty

            };
            return sqlHelper.Execute(sqlCmdText, param) > 0;

        }

        internal bool UpdateLabelStyleItemProperty(LabelStyleItemProperty itemProperty)
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_LABEL_STYLE_ITEM_PROPERTY
                                SET PropertyType = @PropertyType
	                                ,ValueType = @PropertyValueType
	                                ,PropertyValue = @PropertyValue
	                                ,Remark = @Remark
	                                ,ModifyDate = GETDATE()
	                                ,ModifyUser = 'YGJ'
                                WHERE ID = @PropertyID;";
            if (itemProperty.PropertyValueType == LabelStyleItemPropertyValueType.Compute)
            {
                sqlCmdText += @"IF EXISTS (SELECT *
			                                FROM dbo.TB_SYS_SCRIPT_REFERENCE WITH(NOLOCK)
			                                WHERE ForeignID = @ForeignID
			                                AND ForeignType = @ForeignType
		                                  )
                                BEGIN
	                                UPDATE dbo.TB_SYS_SCRIPT_REFERENCE
	                                SET ScriptID = @ScriptID
		                                ,ModifyDate = GETDATE()
		                                ,ModifyUser = 'YGJ'
	                                WHERE ForeignID = @ForeignID
	                                AND ForeignType = @ForeignType
	                                AND ScriptID != @ScriptID
                                END
                                ELSE 
                                BEGIN
                                    DELETE FROM dbo.TB_SYS_SCRIPT_REFERENCE WHERE ForeignID = @ForeignID AND ForeignType = @ForeignType; 
	                                INSERT INTO dbo.TB_SYS_SCRIPT_REFERENCE(ScriptID		,ForeignID		,ForeignType	,Usable
											                                ,CreateDate		,CreateUser		,ModifyDate		,ModifyUser)
									                                VALUES(	@ScriptID		,@ForeignID		,@ForeignType	,1
											                                ,GETDATE()		,'YGJ'			,GETDATE()		,'YGJ')
                                END";
            }
            var scriptId = 0;
            int.TryParse(itemProperty.PropertyValue, out scriptId);
            var param = new
            {
                PropertyID = itemProperty.ID,
                PropertyType = itemProperty.PropertyType,
                PropertyValueType = itemProperty.PropertyValueType,
                PropertyValue = itemProperty.PropertyValue,
                Remark = itemProperty.Remark,
                ForeignID = itemProperty.ID,
                ForeignType = ScriptRelatedType.LabelStyleItemProperty,
                ScriptID = scriptId
            };
            return sqlHelper.Execute(sqlCmdText, param) > 0;
        }

        internal bool DeleteLabelStyleItemProperty(int propertyId)
        {
            var sqlCmdText = @"UPDATE dbo.TB_SYS_LABEL_STYLE_ITEM_PROPERTY
                                SET Usable = 0
                                WHERE ID = @ID ";
            var param = new
            {
                ID = propertyId
            };
            return sqlHelper.Execute(sqlCmdText, param) > 0;
        }
    }
}
