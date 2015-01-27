#coding:utf-8

from sqlalchemy import *
import uuid
import datetime

Base = declarative_base()

class Grade(Base):
    __tablename__ = "grades"

    id = Column(String(36),primary_key=True,nullable=False,default=uuid.uuid4())
    name = Column(string(50),nullable=False)
    start_year = Column(Integer,nullable=False)
    graduation_year = Column(Integer)
    add_time = Column(DateTime,default=datetime.now())

    classes = relationship("classes")
    students = relationship("students")

class Class(Base):
    __tablename__ = "classes"

    id = Column(String(36),primary_key=True,default=uuid.uuid4())
    grade_id = Column(String(36),ForeignKey("grades.id"))
    name = Column(String(50),nullable=False)
    add_time = Column(DateTime,default=datetime.now())

    students = relationship("students")

class Student(Base):
    __tablename = "students"

    id = Column(String(36),primary_key=True,nullable=False,default=uuid.uuid4())
    grade_id = Column(String(36),ForeignKey("grades.id"))
    class_id = Column(String(36),ForeignKey("classes.id"))
    name = Column(String(50),nullable=False)
    sex = Column(BOOLEAN,default=True)
    tel_num = Column(String(15),nullable=False)
    address =  Column(String(200),nullable=False)
    add_time = Column(DateTime,default=datetime.now())