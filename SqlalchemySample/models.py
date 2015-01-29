# coding:utf-8

import uuid
import datetime
from sqlalchemy.orm import relationship
from sqlalchemy.ext.declarative.api import declarative_base
from sqlalchemy.sql.schema import Column, ForeignKey
from sqlalchemy.sql.sqltypes import String, Integer,DateTime, Boolean

Base = declarative_base()

class Grade(Base):
    __tablename__ = "grades"

    id = Column(String, primary_key=True, nullable=False, default=str(uuid.uuid4()))
    name = Column(String(50), nullable=False)
    start_year = Column(Integer, nullable=False)
    graduation_year = Column(Integer)
    add_time = Column(DateTime, default=datetime.datetime.now())

    classes = relationship("Class")
    students = relationship("Student")

class Class(Base):
    __tablename__ = "classes"

    id = Column(String(36), primary_key=True, default=str(uuid.uuid4()))
    grade_id = Column(String(36),ForeignKey("grades.id"))
    name = Column(String(50), nullable=False)
    add_time = Column(DateTime, default=datetime.datetime.now())

    students = relationship("Student")

class Student(Base):
    __tablename__ = "students"

    id = Column(String(36), primary_key=True, nullable=False, default=str(uuid.uuid4()))
    grade_id = Column(String(36), ForeignKey("grades.id"))
    class_id = Column(String(36), ForeignKey("classes.id"))
    name = Column(String(50), nullable=False)
    sex = Column(Boolean, default=True)
    tel_num = Column(String(15), nullable=False)
    address = Column(String(200), nullable=False)
    add_time = Column(DateTime, default=datetime.datetime.now())
