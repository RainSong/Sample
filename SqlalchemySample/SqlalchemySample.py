#coding:utf-8

import dataHelper

if __name__=="__main__":
    grade_count = get_grade_count()
    class_count = get_class_count()
    student_count = get_student_count()

    print("���ݿ����Ѿ��У�{0}����ͣ�{1}���༶��{2}��ѧ��".format(grade_count,class_count,student_count))