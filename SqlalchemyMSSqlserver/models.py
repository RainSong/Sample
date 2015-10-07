# coding:utf-8

import uuid
import datetime
from sqlalchemy.orm import relationship
from sqlalchemy.ext.declarative.api import declarative_base
from sqlalchemy.sql.schema import Column, ForeignKey
from sqlalchemy.sql.sqltypes import String, Integer,DateTime, Boolean

Base = declarative_base()

class Clerk(Base):
    __tablename__='Clerk'

    ID=Column(Integer,primary_key=True)
    C_UID=Column(Integer,nullable=False)
    C_StoreID=Column(Integer,nullable=False)
    C_EntityStoreID=Column(Integer,nullable=False)
    C_Status=Column(Integer,nullable=False,default=0)
    C_AddTime=Column(DateTime,nullable=False,default=datetime.datetime.now())
    C_Remark=Column(String(500))


