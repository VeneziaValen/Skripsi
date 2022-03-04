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


#Baca data
print("======================== Pelatihan Data dengan Gradient Boosting ========================")
print("=========================================================================================")
print("Menghubungkan dengan Database...")

con = pyodbc.connect('Driver={SQL Server};'
                      'Server=DESKTOP-0NDUKK7\SQLEXPRESS;'
                      'Database=Skripsi;'
                      'Trusted_Connection=yes;')

cursor = con.cursor()
cursor.execute('SELECT * FROM pelatihan')

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

for i in range (len(df)):
    print ("Membaca Data ke-" ,i+1)
    if df[i][1]=="Hijau":
        for j in range(6):
            x = rasterio.open(df[i][j+2])
            h = x.height
            w = x.width
            x.crs
            z = x.read(1).astype('float64')
            if j == 0:
                ri = z.reshape(z.size,1)
            else:
                y = z.reshape(z.size,1)
                ri = np.append(ri,y,axis=1)
        if len(r1) == 0:
            r1=ri
        else:
            r1 = np.append(r1,ri,axis=0)
    elif df[i][1]=="Hijau Sebagian":
        for j in range(6):
            x = rasterio.open(df[i][j+2])
            h = x.height
            w = x.width
            x.crs
            z = x.read(1).astype('float64')
            if j == 0:
                ri = z.reshape(z.size,1)
            else:
                y = z.reshape(z.size,1)
                ri = np.append(ri,y,axis=1)
        if len(r2)== 0:
            r2=ri
        else:
            r2 = np.append(r2,ri,axis=0)
    else:
        for j in range(6):
            x = rasterio.open(df[i][j+2])
            h = x.height
            w = x.width
            x.crs
            z = x.read(1).astype('float64')
            if j == 0:
                ri = z.reshape(z.size,1)
            else:
                y = z.reshape(z.size,1)
                ri = np.append(ri,y,axis=1)
        if len(r3)== 0:
            r3=ri
        else:
            r3 = np.append(r3,ri,axis=0)

o=0
for i in range(r1.shape[0]):
    if(r1[i][0]!=0.0):
        o=o+1

r1_clean = np.empty((o,6))

k=0
for i in range(r1.shape[0]):
    if(r1[i][0]!=0):
        r1_clean[k] = r1[i]
        k=k+1

a = ["Hijau" for i in range(r1_clean.shape[0])]
a = pd.DataFrame(a)
r1_clean = np.append(r1_clean,a,axis=1)

o=0
for i in range(r2.shape[0]):
    if(r2[i][0]!=0.0):
        o=o+1

r2_clean = np.empty((o,6))

k=0
for i in range(r2.shape[0]):
    if(r2[i][0]!=0):
        r2_clean[k] = r2[i]
        k=k+1

a = ["Hijau Sebagian" for i in range(r2_clean.shape[0])]
a = pd.DataFrame(a)
r2_clean = np.append(r2_clean,a,axis=1)

o=0
for i in range(r3.shape[0]):
    if(r3[i][0]!=0.0):
        o=o+1

r3_clean = np.empty((o,6))

k=0
for i in range(r3.shape[0]):
    if(r3[i][0]!=0):
        r3_clean[k] = r3[i]
        k=k+1

a = ["Impervious" for i in range(r3_clean.shape[0])]
a = pd.DataFrame(a)
r3_clean = np.append(r3_clean,a,axis=1)

r = np.append(r1_clean, (np.append(r2_clean,r3_clean,axis=0)),axis=0)
print("\nJumlah piksel data latih:", r.shape[0], "piksel")
print("Selesai Membaca Data.")
print("\n=========================================================================================\n")
print("========================= Proses Data dengan Gradient Boosting ==========================\n")
print("Membagi data latih dan data validasi...")

y_train = r[:,6]
train = r[:, :6]

state = 12  
test_size = 0.35  
  
X_train, X_val, y_train, y_val = train_test_split(train, y_train,  
    test_size=test_size, random_state=state)
print("Pembagian selesai...")

print("\nMembangun model...")
print("Proses membutuhkan waktu. Mohon tunggu sebentar...")

gb_clf2 = GradientBoostingClassifier(n_estimators=50, learning_rate=0.1, random_state=0, max_depth=5)

gb_clf2.fit(X_train, y_train)
predictions = gb_clf2.predict(X_val)

print("Model selesai dibangun.")
print("Proses validasi dengan f1 score...")
print("Classification Report")
score = classification_report(y_val, predictions, output_dict=True)
print(classification_report(y_val, predictions))

f1 = open(r"E:\\Skripsi\\Program\\Python\\Hasil Training\\f1_hijau.txt","w+")
f1.write("%s\n%s\n%s\n" % (str("%.4f" % (score['Hijau']['precision'])), str("%.4f" % (score['Hijau']['recall'])), str("%.2f" % (score['Hijau']['f1-score']*100))))
f1.close()

f1 = open(r"E:\\Skripsi\\Program\\Python\\Hasil Training\\f1_hs.txt","w+")
f1.write("%s\n%s\n%s\n" % (str("%.4f" % (score['Hijau Sebagian']['precision'])), str("%.4f" % (score['Hijau Sebagian']['recall'])), str("%.2f" % (score['Hijau Sebagian']['f1-score']*100))))
f1.close()

f1 = open(r"E:\\Skripsi\\Program\\Python\\Hasil Training\\f1_imper.txt","w+")
f1.write("%s\n%s\n%s\n" % (str("%.4f" % (score['Impervious']['precision'])), str("%.4f" % (score['Impervious']['recall'])), str("%.2f" % (score['Impervious']['f1-score']*100))))
f1.close()

f1 = open(r"E:\\Skripsi\\Program\\Python\\Hasil Training\\f1_macro.txt","w+")
f1.write("%s\n%s\n%s\n" % (str("%.4f" % (score['macro avg']['precision'])), str("%.4f" % (score['macro avg']['recall'])), str("%.2f" % (score['macro avg']['f1-score']*100))))
f1.close()


print("\n=========================================================================================\n")
print("==================================== Menyimpan Model ====================================\n")
joblib.dump(gb_clf2, "E:\Skripsi\Program\Python\Hasil Training\model.pkl")
print("Selesai menyimpan model\n")
print("\n=========================================================================================\n")
print("=============================== Proses Pelatihan Selesai ================================\n")