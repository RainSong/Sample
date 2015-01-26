#encoding:utf-8

import os
import sys
import importlib

basePath = os.getcwd()+"\Models\\"
sys.path.append(basePath)

def get_files():
    files = []
    paths = os.listdir(basePath)
    for p in paths:
        #p = basePath + p
        #if os.path.isfile(p):
        files.append(p)
    return files

if __name__ == "__main__":
   
    files = get_files()
    print(files)
    for f in files:
        m = importlib.import_module('Model1')
        class1 = getattr(m,'class1')
        c = class1()
        method = getattr(class1,'say')
        method()
        print(method)
        #print(m)
    print(basePath)
