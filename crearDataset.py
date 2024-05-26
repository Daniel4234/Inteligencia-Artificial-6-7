import cv2
import os

# Ruta del directorio para guardar las imágenes
dir_dataset = 'datasets/personal'

# Crear el directorio si no existe
os.makedirs(dir_dataset, exist_ok=True)

# Nombre de la persona
nombre_persona = input('Ingresa tu nombre: ')
dir_persona = os.path.join(dir_dataset, nombre_persona)
os.makedirs(dir_persona, exist_ok=True)

# Iniciar la cámara
camara = cv2.VideoCapture(0)

# Contador de imágenes
contador = 0

print('Presiona "q" para salir')

while True:
    # Leer un fotograma de la cámara
    ret, frame = camara.read()

    # Mostrar el fotograma
    cv2.imshow('Captura de imágenes', frame)

    # Esperar una tecla presionada
    tecla = cv2.waitKey(1) & 0xFF

    # Si se presiona la tecla 'q', salir del bucle
    if tecla == ord('q'):
        break

    # Si se presiona la barra espaciadora, guardar la imagen
    if tecla == ord(' '):
        nombre_archivo = os.path.join(dir_persona, f'imagen_{contador}.jpg')
        cv2.imwrite(nombre_archivo, frame)
        contador += 1
        print(f'Imagen guardada: {nombre_archivo}')

# Liberar la cámara y cerrar las ventanas
camara.release()
cv2.destroyAllWindows()