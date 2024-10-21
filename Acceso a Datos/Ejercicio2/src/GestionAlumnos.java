import java.io.*;
import java.util.*;

public class GestionAlumnos {
    private List<Alumno> alumnos;

    public GestionAlumnos() {
        this.alumnos = new ArrayList<>();
    }

    // Leer el fichero CSV
    public void importarAlumnos(String archivoCSV) throws IOException {
        BufferedReader br = new BufferedReader(new FileReader(archivoCSV));
        String linea;
        while ((linea = br.readLine()) != null) {
            String[] datos = linea.split(",");
            String nombre = datos[0];
            int edad = Integer.parseInt(datos[1]);
            String ciclo = datos[2];
            double notaMedia = Double.parseDouble(datos[3]);
            Alumno alumno = new Alumno(nombre, edad, ciclo, notaMedia);
            alumnos.add(alumno);
        }
        br.close();
    }

    // Imprimir todos los alumnos
    public void imprimirAlumnos() {
        for (Alumno alumno : alumnos) {
            System.out.println(alumno);
        }
    }

    // Buscar alumno con mayor nota
    public Alumno alumnoConMayorNota() {
        if (alumnos.isEmpty()) return null;
        Alumno maxAlumno = alumnos.get(0);
        for (Alumno alumno : alumnos) {
            if (alumno.getNotaMedia() > maxAlumno.getNotaMedia()) {
                maxAlumno = alumno;
            }
        }
        return maxAlumno;
    }

    // Guardar los alumnos aprobados en un nuevo fichero
    public void generarArchivoAprobados(String archivoSalida) throws IOException {
        BufferedWriter bw = new BufferedWriter(new FileWriter(archivoSalida));
        for (Alumno alumno : alumnos) {
            if (alumno.getNotaMedia() >= 5.0) {
                bw.write(alumno.toCSV());
                bw.newLine();
            }
        }
        bw.close();
    }
}

