# Creación de ventanas con pyqt y qt designer

## Ejercicio 2: Crea dos ventanas con qt designer que registre información y que con un botón podamos mostrar la informacióno de otra

```Python

#importamos las librerías necesarias
import sys
from PyQt6 import QtWidgets, uic
from PyQt6.QtWidgets import QMessageBox


#Carga la interfaz gráfica y conecta los botones
class Ventana(QtWidgets.QMainWindow):
    '''Esta es la clase principal'''
    #Inicializamos la ventana y conectamos los botones
    def __init__(self, padre=None):
        #Inicializa la ventana
        QtWidgets.QMainWindow.__init__(self, padre)
        uic.loadUi("Ejemplo2.ui",self) #Lee el archivo de QtDesigner
        self.setWindowTitle("Ejemplo") #Título de la ventana
        
        #Conectar botón a función
        self.elabel.clicked.connect(self.funcion)
        self.eProgress.clicked.connect(self.funcion2)
        self.current_value = 0
        
    def funcion(self):
        if self.label.text() == "":
            self.label.setText("Hola clase")
        else:
            self.label.setText("")

    def funcion2(self):
            if self.current_value <= self.progressBar.maximum():
                self.current_value += 5
                self.progressBar.setValue(self.current_value)


# se crea la instancia de la aplicación
app = QtWidgets.QApplication(sys.argv)
# se crea la instancia de la ventana
miVentana = Ventana()
# se muestra la ventana 
miVentana.show()
# se entrega el control al sistema operativo
sys.exit(app.exec())