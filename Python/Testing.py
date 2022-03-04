from re import T
from osgeo import gdal
import os
from PIL import Image
import cv2
import rasterio
from rasterio import plot
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
from PIL import Image
import joblib
import sys
import pyodbc 
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report, confusion_matrix
from sklearn.ensemble import GradientBoostingClassifier
import seaborn as sns
import itertools
from sys import argv


#Baca data
print("======================= Klasifikasi Data dengan Gradient Boosting =======================")
print("=========================================================================================")
print("Menghubungkan dengan Database...")

arg_data = argv[1].split(',')
arg_data[0] = arg_data[0].replace(";", " ")

kecamatan = arg_data[0]
tgl = arg_data[1]
#kecamatan = 'Beji'
#tgl = '2014-03-05'

con = pyodbc.connect('Driver={SQL Server};'
                      'Server=DESKTOP-0NDUKK7\SQLEXPRESS;'
                      'Database=Skripsi;'
                      'Trusted_Connection=yes;')

cursor = con.cursor()
cursor.execute("SELECT * FROM pengujian WHERE kecamatan=? AND tanggal=?", (kecamatan,tgl))

print("Database terhubung.")
print("\n=========================================================================================\n")
print("Membaca Data...")

df = []
r = []
r1 = []
r2 = []
r3 = []

for row in cursor.fetchall():
    df.append(row)

for j in range(6):
        x = rasterio.open(df[0][j+3])
        #print(inputPath + bandList[i])
        h = x.height
        w = x.width
        x.crs
        z = x.read(1).astype('float64')
        if j == 0:
            test_data = z.reshape(z.size,1)
        else:
            y = z.reshape(z.size,1)
            test_data = np.append(test_data,y,axis=1)

print("Selesai membaca data.")
print("Kecamatan:", kecamatan)
print("Tanggal:",tgl)
print("Ukuran Data:", test_data.shape[0],"piksel\n")

print("Memuat model...")
gb_clf2 = joblib.load("E:\Skripsi\Program\Python\Hasil Training\model.pkl")

print("Melakukan klasifikasi...")
pred = gb_clf2.predict(test_data)
h=0 
hs=0
im = 0
#for i in range(len(pred)):
#    if pred[i] == "Hijau":
#        h +=1
#    if pred[i] == "Hijau Sebagian":
#        hs +=1
#    if pred[i] == "Impervious":
#        im +=1
#print("Hijau:",h,"piksel")
#print("Hijau Sebagian:",hs,"piksel")
#print("Impervious:",im,"piksel")



print("Membuat citra hasil klasifikasi...")
red = np.array(z).reshape(x.height,x.width).astype(np.uint8)
green = np.array(z).reshape(x.height,x.width).astype(np.uint8)
blue = np.array(z).reshape(x.height,x.width).astype(np.uint8)

k=0
for i in range(x.height):
    for j in range(x.width):
        if (red[i][j] != 0 and green[i][j] != 0 and blue[i][j] != 0):
            if pred[k] == "Hijau":
                h +=1
            elif pred[k] == "Hijau Sebagian":
                hs +=1
            elif pred[k] == "Impervious":
                im +=1
        k=k+1
hijau = str(h * 900)
hjs = str(hs * 900)
imper = str(im * 900)
k =0
for i in range(x.height):
    for j in range(x.width):
        if (red[i][j] != 0 and green[i][j] != 0 and blue[i][j] != 0):
            if pred[k] == "Hijau":
                red[i][j] = 16
                green[i][j] = 112
                blue[i][j] = 16
            elif pred[k] == "Hijau Sebagian":
                red[i][j] = 222
                green[i][j] = 215
                blue[i][j] = 80
            elif pred[k] == "Impervious":
                red[i][j] = 223
                green[i][j] = 32
                blue[i][j] = 32
        k +=1

hasil = np.dstack((red,green,blue))

print("Menyimpan citra hasil klasifikasi...")
citra = Image.fromarray(hasil,'RGB')
path = "E:\\Skripsi\\Program\\Python\\Hasil Testing\\"+kecamatan+"\\"+ kecamatan +'_'+tgl+'.png'
citra.save(path)


exist = cursor.execute("SELECT COUNT(*)AS Row_Count FROM hasil WHERE kecamatan=? AND tanggal=?", (kecamatan,tgl))
co = exist.fetchone()[0]

if co == 0:
    cursor.execute("INSERT INTO hasil(kecamatan,tanggal,citra,hijau,hijausebagian,impervious) VALUES(?,?,?,?,?,?)",(kecamatan,tgl,path,hijau,hjs,imper))
    con.commit()
else:
    cursor.execute("DELETE FROM hasil  WHERE kecamatan=? AND tanggal=?", (kecamatan,tgl))
    cursor.execute("INSERT INTO hasil(kecamatan,tanggal,citra,hijau,hijausebagian,impervious) VALUES(?,?,?,?,?,?)",(kecamatan,tgl,path,hijau,hjs,imper))
    con.commit()
print("Selesai menyimpan citra\n")
print("\n=========================================================================================\n")
print("============================== Proses Klasifikasi Selesai ===============================\n")
