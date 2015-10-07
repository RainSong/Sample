# coding:utf-8
import dataHelper

print('start sqlalchemy whith mssqlserver')
try:
    count = dataHelper.getCount()
    print(count)
except Exception as e:
    print(e)
