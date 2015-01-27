#coding:utf-8

from sqlalchemy import *
from models import *

dbPath = "sqlite:///" + os.path.split(os.path.realpath(__file__))[0] + "\\Data\\db1.sqlite"

engine = create_engine(dbPath,echo=True)
session = sessionmaker(bind=engine)

def get_grade_count():
    """��ȡ�꼶����"""
    return session.query(Grade).count()

def get_class_count():
    """��ȡ�༶����"""
    return session.query(Class).count()

def get_student_count():
    """��ȡѧ��������"""
    return session.query(Student).count()

def exists_grade(name):
    """�ж��꼶�Ƿ��Ѿ����ڱ�����"""
    count = session.query(Grade).filter(name=name).count()
    return count > 0

def exists_class(name,grade_id):
    """�ж�ĳ���꼶���Ƿ��Ѿ�����ĳ���༶��"""
    count = session.query(Class).filter(name=name,grade_id=grade_id).count()
    return count > 0

def add_gread(grade):
    """���һ���꼶"""
    if grade == None:
        return False
    if grade.name == None or len(grade.name) == 0:
        print("�꼶���Ʋ���Ϊ��")
        return False
    if exists_grade(grade.name):
        print("���ݿ����Ѿ���������Ϊ{0}���꼶��".format(grade.name))
        return False
    if grade.start_year == None or grade.start_year == 0:
        print("�꼶��ѧ��ݲ���Ϊ��")
        return False
    session.add(grade)

def add_class(cla):
    """���һ���༶"""
    if cla == None:
        return False
    if cla.grade_id == None or len(cla.grade_id) == 0:
        print("�꼶ID����Ϊ��")
        return False
    if cla.name == None or len(cla.name)==0:
        print("�꼶���Ʋ���Ϊ��")
        return False
    if exists_class(cla.name,cla.grade_id):
        print("��ǰ�꼶���Ѿ�����Ϊ{0}�İ༶��".format(cla.name))
        return False
    session.add(cla)
    return True

def add_student(stu):
    """���һ��ѧ��"""
    if stu == None:
        return False
    if stu.grade_id == None or len(stu.grade_id) == 0:
        print("ѧ���꼶ID����Ϊ��")
        return False
    if stu.class_id == None or len(stu.class_id) == 0:
        print("ѧ���༶ID����Ϊ��")
        return False
    if stu.name == None or len(stu.name) == 0:
        print("ѧ����������Ϊ��")
        return False
    session.add(stu)
    return True
    