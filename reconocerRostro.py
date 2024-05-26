import os
import numpy as np
import cv2
from tensorflow.keras.models import load_model # type: ignore
from tensorflow.keras.preprocessing.image import img_to_array # type: ignore

# Ruta al modelo entrenado
modelo_path = 'modelo_entrenado.keras'
# Ruta a la imagen de prueba
imagen_path = 'imagen_prueba.jpg'

# Cargar el modelo entrenado
modelo = load_model(modelo_path)

# Verificar que la imagen de prueba exista
if not os.path.exists(imagen_path):
    print(f"Error: La imagen de prueba no existe en la ruta especificada: {imagen_path}")
    exit()

# Cargar la imagen de prueba
imagen = cv2.imread(imagen_path)
if imagen is None:
    print(f"Error: No se pudo cargar la imagen de prueba: {imagen_path}")
    exit()

# Preprocesar la imagen
imagen = cv2.resize(imagen, (224, 224))
imagen = img_to_array(imagen)
imagen = np.expand_dims(imagen, axis=0)
imagen = imagen / 255.0  # Normalizar la imagen

# Realizar la predicción
prediccion = modelo.predict(imagen)
clase_predicha = np.argmax(prediccion, axis=1)

# Mapeo de índices de clases a nombres de clases (ajustar según las clases que tengas)
clases = ['Alex', 'Otra Persona', 'Tom Hanks', 'Otro Famoso']

# Determinar si es un famoso o Alex
nombre_clase = clases[clase_predicha[0]]
es_famoso = nombre_clase in ['Tom Hanks', 'Otro Famoso']

# Imprimir el resultado
if es_famoso:
    print(f"Predicción: {nombre_clase} es una persona famosa con una probabilidad de {prediccion[0][clase_predicha[0]]:.2f}")
else:
    print(f"Predicción: {nombre_clase} es Alex con una probabilidad de {prediccion[0][clase_predicha[0]]:.2f}")
