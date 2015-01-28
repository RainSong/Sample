#coding:utf-8
import dataHelper

if __name__=="__main__":
    grade_count = dataHelper.get_grade_count()
    class_count = dataHelper.get_class_count()
    student_count = dataHelper.get_student_count()

    print("共有年级{0}个，班级{1}个，学生{2}个".format(grade_count,class_count,student_count))