import os
import numpy as np
from tensorflow.keras.preprocessing.image import ImageDataGenerator # type: ignore
from tensorflow.keras.applications import VGG16 # type: ignore
from tensorflow.keras.layers import Dense, Flatten, Dropout # type: ignore
from tensorflow.keras.models import Model # type: ignore
from tensorflow.keras.optimizers import Adam # type: ignore

# Directorio raíz que contiene subdirectorios para cada clase
base_dir = r'C:\Users\danie\OneDrive\Documentos\IA-RF\datasets'

# Verificar que las rutas existan
train_dir = os.path.join(base_dir, 'train')
validation_dir = os.path.join(base_dir, 'validation')

if not os.path.isdir(train_dir):
    print(f"Error: La ruta de entrenamiento no existe: {train_dir}")
    exit()

if not os.path.isdir(validation_dir):
    print(f"Error: La ruta de validación no existe: {validation_dir}")
    exit()

# Preprocesamiento de datos
train_datagen = ImageDataGenerator(
    rescale=1./255,
    shear_range=0.2,
    zoom_range=0.2,
    horizontal_flip=True
)

validation_datagen = ImageDataGenerator(rescale=1./255)

# Generar datos de entrenamiento y validación
train_generator = train_datagen.flow_from_directory(
    train_dir,
    target_size=(224, 224),
    batch_size=32,
    class_mode='categorical'
)

validation_generator = validation_datagen.flow_from_directory(
    validation_dir,
    target_size=(224, 224),
    batch_size=32,
    class_mode='categorical'
)

# Cargar la red base VGG16 pre-entrenada
base_model = VGG16(weights='imagenet', include_top=False, input_shape=(224, 224, 3))

# Agregar capas adicionales
x = base_model.output
x = Flatten()(x)
x = Dense(512, activation='relu')(x)
x = Dropout(0.5)(x)
predicciones = Dense(train_generator.num_classes, activation='softmax')(x)

# Construir el modelo
modelo = Model(inputs=base_model.input, outputs=predicciones)

# Congelar las capas de la red base
for capa in base_model.layers:
    capa.trainable = False

# Compilar el modelo
modelo.compile(optimizer=Adam(), loss='categorical_crossentropy', metrics=['accuracy'])

# Entrenar el modelo
epochs = 10
modelo.fit(
    train_generator,
    epochs=epochs,
    validation_data=validation_generator
)

# Guardar el modelo entrenado en formato Keras
modelo.save('modelo_entrenado.keras')
