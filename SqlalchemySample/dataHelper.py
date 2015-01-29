#coding:utf-8

import os
from sqlalchemy.orm.session import sessionmaker
from sqlalchemy.engine import create_engine
from models import Grade,Class,Student

dbPath = "sqlite:///" + os.path.split(os.path.realpath(__file__))[0] + "\\Data\\db1.sqlite"

print(dbPath)

engine = create_engine(dbPath,echo=False)
Session = sessionmaker(bind=engine)
session = Session()

def get_grade_count():
    """获取当前数据库中年级数量"""
    return session.query(Grade).count()

def get_class_count():
    """获取当前数据裤中班级的数量"""
    return session.query(Class).count()

def get_student_count():
    """获取当前数据库中学生的数量"""
    return session.query(Student).count()

def exists_grade(name):
    """检查名称是否存在某个名称的年级"""
    count = session.query(Grade).filter(Grade.name==name).count()
    return count > 0

def exists_class(name,grade_id):
    """检查某个年级下是否存在某个名称的班级"""
    count = session.query(Class).filter(Class.name==name,Class.grade_id==grade_id).count()
    return count > 0

def add_gread(grade):
    """添加一个年级"""
    if grade == None:
        return False
    if grade.name == None or len(grade.name) == 0:
        print("年级名称不可为空")
        return False
    if exists_grade(grade.name):
        print("已经存在名称为{0}的年级了".format(grade.name))
        return False
    if grade.start_year == None or grade.start_year == 0:
        print("入学年份不能为空")
        return False
    session.add(grade)
    session.commit()

def add_class(cla):
    """添加一个班级"""
    if cla == None:
        return False
    if cla.grade_id == None or len(cla.grade_id) == 0:
        print("年级ID不能为空")
        return False
    if cla.name == None or len(cla.name)==0:
        print("班级名称不能为空")
        return False
    if exists_class(cla.name,cla.grade_id):
        print("当前年级下已经存在名称为{0}的班级了".format(cla.name))
        return False
    session.add(cla)
    session.commit()
    return True

def add_student(stu):
    """添加一个学生"""
    if stu == None:
        return False
    if stu.grade_id == None or len(stu.grade_id) == 0:
        print("年级ID不能为空")
        return False
    if stu.class_id == None or len(stu.class_id) == 0:
        print("班级ID不能为空")
        return False
    if stu.name == None or len(stu.name) == 0:
        print("学生姓名不能为空")
        return False
    session.add(stu)
    session.commit()
    return True

def get_grade_by_name(grade_name):
    """根据年级的名称查询一个年级"""
    return session.query(Grade).filter(Grade.name==grade_name).first()

def get_class_by_name(class_name):
    """根据班级名称获取一个班级"""
    return session.query(Class).filter(Class.name==class_name).first()