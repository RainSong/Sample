#coding:utf-8

from sqlalchemy import *
from models import *

dbPath = "sqlite:///" + os.path.split(os.path.realpath(__file__))[0] + "\\Data\\db1.sqlite"

engine = create_engine(dbPath,echo=True)
session = sessionmaker(bind=engine)

def get_grade_count():
    """获取年级数量"""
    return session.query(Grade).count()

def get_class_count():
    """获取班级数量"""
    return session.query(Class).count()

def get_student_count():
    """获取学生的数量"""
    return session.query(Student).count()

def exists_grade(name):
    """判断年级是否已经存在表中了"""
    count = session.query(Grade).filter(name=name).count()
    return count > 0

def exists_class(name,grade_id):
    """判断某个年级下是否已经存在某个班级了"""
    count = session.query(Class).filter(name=name,grade_id=grade_id).count()
    return count > 0

def add_gread(grade):
    """添加一个年级"""
    if grade == None:
        return False
    if grade.name == None or len(grade.name) == 0:
        print("年级名称不能为空")
        return False
    if exists_grade(grade.name):
        print("数据库中已经存在名称为{0}的年级了".format(grade.name))
        return False
    if grade.start_year == None or grade.start_year == 0:
        print("年级入学年份不能为空")
        return False
    session.add(grade)

def add_class(cla):
    """添加一个班级"""
    if cla == None:
        return False
    if cla.grade_id == None or len(cla.grade_id) == 0:
        print("年级ID不能为空")
        return False
    if cla.name == None or len(cla.name)==0:
        print("年级名称不能为空")
        return False
    if exists_class(cla.name,cla.grade_id):
        print("当前年级下已经有名为{0}的班级了".format(cla.name))
        return False
    session.add(cla)
    return True

def add_student(stu):
    """添加一个学生"""
    if stu == None:
        return False
    if stu.grade_id == None or len(stu.grade_id) == 0:
        print("学生年级ID不能为空")
        return False
    if stu.class_id == None or len(stu.class_id) == 0:
        print("学生班级ID不能为空")
        return False
    if stu.name == None or len(stu.name) == 0:
        print("学生姓名不能为空")
        return False
    session.add(stu)
    return True
    