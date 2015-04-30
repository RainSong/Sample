using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CodeGenerator
{
    public partial class _default : System.Web.UI.Page
    {
        static GetDataBasesInfo getInfos;
        public string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ServerName"] != null &&
                    Session["UName"] != null &&
                    Session["Upwd"] != null &&
                    !string.IsNullOrEmpty(Session["UName"].ToString().Trim()) &&
                    !string.IsNullOrEmpty(Session["ServerName"].ToString().Trim()) &&
                    !string.IsNullOrEmpty(Session["Upwd"].ToString().Trim()))
                {
                    try
                    {
                        getInfos = new GetDataBasesInfo(Session["ServerName"].ToString(), Session["UName"].ToString(), Session["Upwd"].ToString());
                        bindDataToTree();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                        Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
        private void bindDataToTree() 
        {
            string strServer = getInfos.Name;
            TreeNode root = new TreeNode(strServer);
            List<string> dbs = getInfos.getDataBase("sa", "sa");
            dbs.ForEach(x => 
            {
                TreeNode db = new TreeNode(x);
                db.Expanded = false;
                TreeNode tbT = new TreeNode("表");
                tbT.Value = "t";
                tbT.Expanded = false;
                TreeNode tbV = new TreeNode("视图");
                tbV.Value = "v";
                tbV.Expanded = false;
                TreeNode tbP = new TreeNode("存储过程");
                tbP.Value = "p";
                tbP.Expanded = false;
                TreeNode tbF = new TreeNode("函数");
                tbF.Value = "f";
                tbF.Expanded = false;
                db.ChildNodes.Add(tbT);
                db.ChildNodes.Add(tbV);
                db.ChildNodes.Add(tbP);
                db.ChildNodes.Add(tbF);
                root.ChildNodes.Add(db);
            });
            
            this.TreeView1.Nodes.Add(root);
        }

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.Depth == 1) 
            {
                List<string> tables = getInfos.getTables(e.Node.Text);
                tables.ForEach(t =>
                {
                    TreeNode tb = new TreeNode(t);
                   
                    e.Node.ChildNodes[0].ChildNodes.Add(tb);
                });
                List<string> views = getInfos.getViews(e.Node.Text);

                views.ForEach(v =>
                {
                    TreeNode view = new TreeNode(v);
                    e.Node.ChildNodes[1].ChildNodes.Add(view);
                });

                List<string> procedures = getInfos.getProcedures(e.Node.Text);

                procedures.ForEach(p => 
                {
                    TreeNode procedure = new TreeNode(p);
                    e.Node.ChildNodes[2].ChildNodes.Add(procedure);
                });

                List<string> functions = getInfos.getFunctions(e.Node.Text);

                functions.ForEach(f => 
                {
                    TreeNode function = new TreeNode(f);
                    e.Node.ChildNodes[3].ChildNodes.Add(function);
                });
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = this.TreeView1.SelectedNode;
            if (node.Depth == 3)
            {
                if (node.Parent.Value.Equals("t"))
                {
                    this.labProperies.Text = "表属性";
                    this.RepeaterKeys.Visible = true;
                    this.RepeaterColumns.Visible = true;
                    this.RepeaterIndexes.Visible = true;
                    this.RepeaterParameters.Visible = false;
                    this.RepeaterFunPara.Visible = false;
                    this.RepeaterProperies.DataSource = getInfos.GetTableProperties(node.Parent.Parent.Text, node.Text);
                    this.RepeaterProperies.DataBind();
                    this.RepeaterColumns.DataSource = getInfos.getTableClomns(node.Parent.Parent.Text, node.Text);
                    this.RepeaterColumns.DataBind();
                    DataTable dt = getInfos.getTableKeys(node.Parent.Parent.Text, node.Text);
                    if (dt.Rows.Count > 0)
                    {
                        this.RepeaterKeys.DataSource = dt;
                        this.RepeaterKeys.DataBind();
                    }
                    else 
                    {
                        this.RepeaterKeys.Visible = false;
                    }
                    dt = getInfos.getTableIndex(node.Parent.Parent.Text, node.Text);
                    if (dt.Rows.Count > 0)
                    {
                        this.RepeaterIndexes.DataSource = dt;
                        this.RepeaterIndexes.DataBind();
                    }
                    else 
                    {
                        this.RepeaterIndexes.Visible = false;
                    }
                    strScript = getInfos.getTableScript(node.Parent.Parent.Text, node.Text);//.Replace("\r\n", "<br/>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;").Replace(" ", "&nbsp;&nbsp;");
                }
                else if (node.Parent.Value.Equals("v"))
                {
                    this.RepeaterKeys.Visible = false;
                    this.RepeaterColumns.Visible = true;
                    this.RepeaterIndexes.Visible = true;
                    this.RepeaterParameters.Visible = false;
                    this.RepeaterFunPara.Visible = false;
                    this.labProperies.Text = "视图属性";
                    this.RepeaterProperies.DataSource = getInfos.GetViewProperties(node.Parent.Parent.Text, node.Text);
                    this.RepeaterProperies.DataBind();
                    this.RepeaterColumns.DataSource = getInfos.getViewColmns(node.Parent.Parent.Text, node.Text);
                    this.RepeaterColumns.DataBind();
                    DataTable dt = getInfos.getViewIndex(node.Parent.Parent.Text, node.Text);
                    if (dt.Rows.Count > 0)
                    {
                        this.RepeaterIndexes.DataSource = dt;
                        this.RepeaterIndexes.DataBind();
                    }
                    else 
                    {
                        this.RepeaterIndexes.Visible = false;
                    }
                    strScript = getInfos.getViewScript(node.Parent.Parent.Text, node.Text);//).Replace("\r\n\r\n", "<br/>").Replace("\r\n", "<br/>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;").Replace(" ", "&nbsp;&nbsp;");
                }
                else if (node.Parent.Value.Equals("p")) 
                {
                    this.RepeaterColumns.Visible = false;
                    this.RepeaterIndexes.Visible = false;
                    this.RepeaterKeys.Visible = false;
                    this.RepeaterFunPara.Visible = false;
                    RepeaterParameters.Visible = true;
                    this.labProperies.Text = "存储过程属性";
                    this.RepeaterProperies.DataSource = getInfos.GetProcedureProperties(node.Parent.Parent.Text, node.Text);
                    this.RepeaterProperies.DataBind();
                    DataTable dt = getInfos.getProcedureParamters(node.Parent.Parent.Text, node.Text);
                    if (dt.Rows.Count > 0)
                    {
                        this.RepeaterParameters.DataSource = dt;
                        this.RepeaterParameters.DataBind();
                    }
                    else
                    {
                        this.RepeaterParameters.Visible = false;
                    }
                    strScript = getInfos.getProcedureScript(node.Parent.Parent.Text, node.Text);//).Replace("\r\n\r\n", "<br/>").Replace("\r\n", "<br/>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;").Replace(" ", "&nbsp;&nbsp;");
                }
                else if (node.Parent.Value.Equals("f")) 
                {
                    this.RepeaterColumns.Visible = false;
                    this.RepeaterIndexes.Visible = false;
                    this.RepeaterKeys.Visible = false;
                    this.RepeaterParameters.Visible = false;
                    this.RepeaterFunPara.Visible = true;
                    this.labProperies.Text = "存储过程属性";

                    this.RepeaterProperies.DataSource = getInfos.getFunctionProperties(node.Parent.Parent.Text, node.Text);
                    this.RepeaterProperies.DataBind();
                    DataTable dt = getInfos.getFunctionParameters(node.Parent.Parent.Text, node.Text);
                    if (dt.Rows.Count > 0)
                    {
                        this.RepeaterFunPara.DataSource = dt;
                        this.RepeaterFunPara.DataBind();
                    }
                    else 
                    {
                        this.RepeaterFunPara.Visible = false;
                    }
                    strScript = getInfos.getFunctionScript(node.Parent.Parent.Text, node.Text);//).Replace("\r\n\r\n", "<br/>").Replace("\r\n", "<br/>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace(" ", "&nbsp;&nbsp;");
                    
                }
                this.Literal1.Text = "<pre name='code' class='brush: sql;'>" + strScript + "</pre>";
            }
            
        }
    }
}