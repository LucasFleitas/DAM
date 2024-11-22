
# EJERCICIO 20241004

## LOGIN

```python
import sys
from PyQt6.QtWidgets import QApplication, QMainWindow, QWidget, QGridLayout, QLabel, QLineEdit, QPushButton
from PyQt6.QtCore import Qt
from PyQt6.QtGui import QIcon

class login(QWidget):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("login ejemplo")
        self.setGeometry (600,100,300,300)

        layout = QGridLayout()
        self.usuario = QLineEdit()
        self.contraseña = QLineEdit()
        usuariolabel = QLabel("Usuario")
        contraseñalabel = QLabel("Contraseña")
        self.Consola = QLineEdit()
        label = QLabel()
        layout.addWidget(usuariolabel,0,0)
        layout.addWidget(self.usuario,0,1)

        label = QLabel()
        label.setText ("Contraseña")
        layout.addWidget(contraseñalabel,1,0)
        layout.addWidget(self.contraseña,1,1)
        
        BotonLogin =  QPushButton("login")
        BotonCancel =  QPushButton("cancel")

        layout.addWidget (BotonLogin,2,0)
        BotonLogin.clicked.connect(self.press_button)
        layout.addWidget  (BotonCancel,2,1)
        BotonCancel.clicked.connect(self.press_button)
        
        widget = QWidget()
        layout.addWidget(self.Consola)
        self.setLayout(layout)

    def press_button(self):
        sender = self.sender()
        if (sender.text()== "login" and (self.usuario.text()  == "admin") and (self.contraseña.text() == "admin")):

                self.Consola.setText("Logeado!")
        else:
             self.Consola.setText("Error de login")

if __name__ == "__main__":
    app  = QApplication(sys.argv)
    dialogo_login = login()
    dialogo_login.show()
    sys.exit(app.exec())