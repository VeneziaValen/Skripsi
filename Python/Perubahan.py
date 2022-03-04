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
from sys import argv, path


#Baca data
print("============================== Perubahan Alih Fungsi Lahan ==============================")
print("=========================================================================================")
print("Menghubungkan dengan Database...")

arg_data = argv[1].split(',')
arg_data[0] = arg_data[0].replace(";", " ")

kecamatan = arg_data[0]
tgl1 = arg_data[1]
tgl2 = arg_data[2]
#kecamatan = 'Beji'
#tgl1 = '2014-03-05'
#tgl2 = '2020-12-02'

con = pyodbc.connect('Driver={SQL Server};'
                      'Server=DESKTOP-0NDUKK7\SQLEXPRESS;'
                      'Database=Skripsi;'
                      'Trusted_Connection=yes;')

cursor = con.cursor()


print("Database terhubung.")
print("\n=========================================================================================\n")
print("Membaca Data...")

p1=cursor.execute("SELECT citra FROM hasil WHERE kecamatan=? AND tanggal=?", (kecamatan,tgl1))
path1 = p1.fetchone()[0]
p2=cursor.execute("SELECT citra FROM hasil WHERE kecamatan=? AND tanggal=?", (kecamatan,tgl2))
path2 = p2.fetchone()[0]

citra1 = Image.open(path1)
citra2 = Image.open(path2)

print("Selesai membaca data.")

df = []

w, h = citra1.size

d1 = list(citra1.getdata())
d2 = list(citra2.getdata())

d1 = np.array(d1).reshape(h,w,3)
d2 = np.array(d2).reshape(h,w,3)

red = np.zeros((h,w)).astype(np.uint8)
green = np.zeros((h,w)).astype(np.uint8)
blue = np.zeros((h,w)).astype(np.uint8)

print("Membandingkan citra...")

berubah = 0
tetap = 0

hhs = 0
hi = 0
hsh = 0
hsi = 0
ih = 0
ihs = 0

hj = np.array([16, 112, 16])
hs = np.array([222, 215, 80])
im = np.array([223,  32,  32])

for i in range(h):
    for j in range(w):
        if (d1[i][j] != 0).all() and (d2[i][j] != 0).all():
            if(d1[i][j] == d2[i][j]).all():
                red[i][j] = 255
                green[i][j] = 255
                blue[i][j] = 255
                tetap = tetap + 1
            elif(np.array_equal(d1[i][j], hj) and np.array_equal(d2[i][j], hs)):
                red[i][j] = 240
                green[i][j] = 230
                blue[i][j] = 140
                berubah = berubah + 1
                hhs = hhs + 1
            elif(np.array_equal(d1[i][j], hj) and np.array_equal(d2[i][j], im)):
                red[i][j] = 128
                green[i][j] = 0
                blue[i][j] = 0
                berubah = berubah + 1
                hi = hi + 1
            elif(np.array_equal(d1[i][j], hs) and np.array_equal(d2[i][j], hj)):
                red[i][j] = 152
                green[i][j] = 251
                blue[i][j] = 152
                berubah = berubah + 1
                hsh = hsh + 1
            elif(np.array_equal(d1[i][j], hs) and np.array_equal(d2[i][j], im)):
                red[i][j] = 255
                green[i][j] = 160
                blue[i][j] = 122
                berubah = berubah + 1
                hsi = hsi + 1
            elif(np.array_equal(d1[i][j], im) and np.array_equal(d2[i][j], hj)):
                red[i][j] = 0
                green[i][j] = 100
                blue[i][j] = 0
                berubah = berubah + 1
                ih = ih + 1
            elif(np.array_equal(d1[i][j], im) and np.array_equal(d2[i][j], hs)):
                red[i][j] = 255
                green[i][j] = 165
                blue[i][j] = 0
                berubah = berubah + 1
                ihs = ihs + 1

h_hs = str(hhs * 900)
h_i = str(hi*900)
hs_h = str(hsh*900)
hs_i = str(hsi*900)
i_h = str(ih*900)
i_hs = str(ihs*900)

ttp = str(tetap*900)
brb = str(berubah*900)


hasil = np.dstack((red,green,blue))

print("Menyimpan citra hasil klasifikasi...")
citra = Image.fromarray(hasil,'RGB')
path = "E:\\Skripsi\\Program\\Python\\Hasil Perubahan\\"+kecamatan+"\\"+ kecamatan +'_'+tgl1 +'_'+tgl2 +'.png'
citra.save(path)

exist = cursor.execute("SELECT COUNT(*)AS Row_Count FROM perubahan WHERE kecamatan=? AND (tanggal1=? AND tanggal2=?)", (kecamatan,tgl1,tgl2))
co = exist.fetchone()[0]

if co == 0:
    cursor.execute("INSERT INTO perubahan(kecamatan,tanggal1,tanggal2,citra,hijau_hijausbg,hijau_impervious,hijausbg_hijau,hijausbg_imper,imper_hijau,imper_hijausbg,berubah,tetap) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)",(kecamatan,tgl1,tgl2,path,h_hs,h_i,hs_h,hs_i,i_h,i_hs,brb,ttp))
    con.commit()
else:
    cursor.execute("DELETE FROM perubahan WHERE kecamatan=? AND(tanggal1=? AND tanggal2=?)", (kecamatan,tgl1,tgl2))
    cursor.execute("INSERT INTO perubahan(kecamatan,tanggal1,tanggal2,citra,hijau_hijausbg,hijau_impervious,hijausbg_hijau,hijausbg_imper,imper_hijau,imper_hijausbg,berubah,tetap) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)",(kecamatan,tgl1,tgl2,path,h_hs,h_i,hs_h,hs_i,i_h,i_hs,brb,ttp))
    con.commit()
print("Selesai menyimpan citra\n")
print("\n=========================================================================================\n")