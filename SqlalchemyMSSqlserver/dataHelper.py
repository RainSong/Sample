# coding:utf-8

import os
from sqlalchemy.orm.session import sessionmaker
from sqlalchemy.engine import create_engine
from models import Clerk

engine = create_engine('mssql+pymssql://scott:tiger@localhost/heima')
Session = sessionmaker(bind=engine)
session = Session()

def getCount():
    return  session.query(Clerk).count()
