#coding:utf-8

import dataHelper

if __name__=="__main__":
    grade_count = get_grade_count()
    class_count = get_class_count()
    student_count = get_student_count()

    print("数据库中已经有：{0}个年纪，{1}个班级，{2}个学生".format(grade_count,class_count,student_count))