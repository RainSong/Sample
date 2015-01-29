# coding:utf-8
import dataHelper
import models

if __name__ == "__main__":
  
    grade = models.Grade()
    grade.name = "小(一)"
    grade.start_year = 2014
    dataHelper.add_gread(grade)
    
    grade = dataHelper.get_grade_by_name("小(一)")
    if grade != None:
        cla = models.Class()
        cla.grade_id = grade.id
        cla.name = "1班"
        dataHelper.add_class(cla)
    else:
        print("不存在名称为“小(一)”的年级")
        
    cla = dataHelper.get_class_by_name("1班")
    if cla != None:
        student = models.Student()
        student.grade_id = grade.id
        student.class_id = cla.id
        student.name = "张三"
        student.sex = True
        student.tel_num = "0393-12345678"
        student.address = "河南省濮阳市"
        dataHelper.add_student(student)
    else:
        print("不存在名称为“1班”的班级")    
    grade_count = dataHelper.get_grade_count()
    class_count = dataHelper.get_class_count()
    student_count = dataHelper.get_student_count()
    
    print("共有年级{0}个，班级{1}个，学生{2}个".format(grade_count, class_count, student_count))
