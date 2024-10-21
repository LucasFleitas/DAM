import java.io.IOException;

public class App {
    public static void main(String[] args) {
        GestionAlumnos gestion = new GestionAlumnos();
        try {
            gestion.importarAlumnos("alumnos.csv");
            System.out.println("Lista de alumnos:");
            gestion.imprimirAlumnos();

            // Buscar alumno con mayor nota
            Alumno mejorAlumno = gestion.alumnoConMayorNota();
            System.out.println("\nAlumno con mayor nota:");
            System.out.println(mejorAlumno);

            // Generar archivo con alumnos aprobados
            gestion.generarArchivoAprobados("AlumnosAprobados.csv");
            System.out.println("\nArchivo de aprobados generado con éxito.");

        } catch (IOException e) {
            System.err.println("Error al procesar el archivo: " + e.getMessage());
        }
    }
}
