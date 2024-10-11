import java.io.*; // Importa clases para operaciones de entrada/salida
import java.util.ArrayList; // Importa la clase ArrayList para manejar listas dinámicas
import java.util.List; // Importa la interfaz List
import java.util.Scanner; // Importa la clase Scanner para leer entrada del usuario

// Clase que representa un libro
class Libro {
    // Atributos de la clase Libro
    String titulo; // Título del libro
    String autor; // Autor del libro
    double precio; // Precio del libro
    int anio; // Año de publicación
    String imagen; // Ruta de la imagen del libro

    // Constructor que inicializa los atributos
    public Libro(String titulo, String autor, double precio, int anio, String imagen) {
        this.titulo = titulo; // Asigna el título
        this.autor = autor; // Asigna el autor
        this.precio = precio; // Asigna el precio
        this.anio = anio; // Asigna el año
        this.imagen = imagen; // Asigna la imagen
    }

    // Método para convertir el libro a una cadena para guardar en el archivo
    @Override
    public String toString() {
        return "Título: " + titulo + "\n" + // Formato de salida del título
               "Autor: " + autor + "\n" + // Formato de salida del autor
               "Precio: " + precio + "\n" + // Formato de salida del precio
               "Año: " + anio + "\n" + // Formato de salida del año
               "Imagen: " + imagen + "\n"; // Formato de salida de la imagen
    }

    // Método estático para crear un libro a partir de una cadena
    public static Libro fromString(String str) {
        // Divide la cadena en líneas
        String[] partes = str.split("\n");
        // Crea un nuevo objeto Libro a partir de las partes
        return new Libro(partes[0].substring(8), // Extraer título (elimina "Título: ")
                         partes[1].substring(7), // Extraer autor (elimina "Autor: ")
                         Double.parseDouble(partes[2].substring(8)), // Extraer precio
                         Integer.parseInt(partes[3].substring(6)), // Extraer año
                         partes[4].substring(8)); // Extraer imagen (elimina "Imagen: ")
    }
}

// Clase que gestiona la colección de libros
class Biblioteca {
    private List<Libro> libros; // Lista para almacenar los libros
    private String archivo; // Nombre del archivo para guardar los libros

    // Constructor que inicializa la lista y carga libros desde el archivo
    public Biblioteca(String archivo) {
        this.libros = new ArrayList<>(); // Crea una nueva lista de libros
        this.archivo = archivo; // Asigna el nombre del archivo
        cargarLibros(); // Carga libros desde el archivo
    }

    // Cargar libros desde el archivo
    private void cargarLibros() {
        try (BufferedReader br = new BufferedReader(new FileReader(archivo))) {
            StringBuilder builder = new StringBuilder(); // Para construir una cadena
            String linea;
            while ((linea = br.readLine()) != null) {
                builder.append(linea).append("\n"); // Añade la línea al builder
                if (linea.startsWith("Imagen: ")) { // Verifica el final de un libro
                    libros.add(Libro.fromString(builder.toString())); // Crea y añade el libro
                    builder.setLength(0); // Reinicia el builder para el siguiente libro
                }
            }
        } catch (IOException e) { // Manejo de excepciones
            System.out.println("Error al cargar los libros: " + e.getMessage());
        }
    }

    // Guardar libros en el archivo actual
    public void guardarLibros() {
        guardarLibros(archivo); // Llama al método con el nombre del archivo
    }

    // Guardar libros en un archivo específico
    public void guardarLibros(String archivo) {
        try (BufferedWriter bw = new BufferedWriter(new FileWriter(archivo))) {
            for (Libro libro : libros) {
                bw.write(libro.toString()); // Escribe cada libro en el archivo
            }
        } catch (IOException e) { // Manejo de excepciones
            System.out.println("Error al guardar los libros: " + e.getMessage());
        }
    }

    // Agregar un nuevo libro
    public void agregarLibro(Libro libro) {
        libros.add(libro); // Añade el libro a la lista
        guardarLibros(); // Guarda los cambios en el archivo
    }

    // Modificar un libro existente
    public void modificarLibro(int indice, Libro libro) {
        if (indice >= 0 && indice < libros.size()) { // Verifica que el índice sea válido
            libros.set(indice, libro); // Modifica el libro en el índice indicado
            guardarLibros(); // Guarda los cambios
        }
    }

    // Eliminar un libro
    public void eliminarLibro(int indice) {
        if (indice >= 0 && indice < libros.size()) { // Verifica que el índice sea válido
            libros.remove(indice); // Elimina el libro en el índice indicado
            guardarLibros(); // Guarda los cambios
        }
    }

    // Listar todos los libros
    public List<Libro> listarLibros() {
        return libros; // Devuelve la lista de libros
    }

    // Buscar un libro por título
    public List<Libro> buscarLibro(String criterio) {
        List<Libro> resultados = new ArrayList<>(); // Lista para almacenar resultados
        for (Libro libro : libros) { // Itera sobre la lista de libros
            if (libro.titulo.toLowerCase().contains(criterio.toLowerCase())) { // Verifica si el título contiene el criterio
                resultados.add(libro); // Añade el libro a los resultados
            }
        }
        return resultados; // Devuelve la lista de resultados
    }

    // Eliminar todos los libros
    public void eliminarTodos() {
        libros.clear(); // Limpia la lista de libros
        guardarLibros(); // Guarda los cambios
    }
}

// Clase principal de la aplicación
public class App {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in); // Crea un objeto Scanner para leer entrada
        Biblioteca biblioteca = new Biblioteca("libros.txt"); // Crea una nueva biblioteca

        while (true) { // Bucle infinito para mostrar el menú
            System.out.println("\n1. Agregar libro");
            if (biblioteca.listarLibros().isEmpty()) { // Comprueba si la lista de libros está vacía
                System.out.println("2. Listar libros");
                System.out.println("3. Modificar libro");
                System.out.println("4. Eliminar libro");
                System.out.println("5. Buscar libro");
            } else {
                System.out.println("2. Listar libros");
                System.out.println("3. Modificar libro");
                System.out.println("4. Eliminar libro");
                System.out.println("5. Buscar libro");
            }
            System.out.println("6. Eliminar todos los libros");
            System.out.println("7. Guardar como");
            System.out.println("8. Salir");

            System.out.print("Elige una opción: ");
            int opcion = scanner.nextInt(); // Lee la opción elegida por el usuario
            scanner.nextLine(); // Limpiar el buffer

            switch (opcion) {
                case 1: // Agregar libro
                    System.out.print("Título: ");
                    String titulo = scanner.nextLine(); // Lee el título
                    System.out.print("Autor: ");
                    String autor = scanner.nextLine(); // Lee el autor
                    System.out.print("Precio: ");
                    double precio = scanner.nextDouble(); // Lee el precio
                    System.out.print("Año: ");
                    int anio = scanner.nextInt(); // Lee el año
                    scanner.nextLine(); // Limpiar el buffer
                    System.out.print("Ruta de la imagen: ");
                    String imagen = scanner.nextLine(); // Lee la ruta de la imagen
                    biblioteca.agregarLibro(new Libro(titulo, autor, precio, anio, imagen)); // Agrega el libro
                    break;

                case 2: // Listar libros
                    if (biblioteca.listarLibros().isEmpty()) { // Verifica si la lista está vacía
                        System.out.println("No hay libros para listar.");
                    } else {
                        List<Libro> libros = biblioteca.listarLibros(); // Obtiene la lista de libros
                        for (int i = 0; i < libros.size(); i++) {
                            System.out.println(i + ": " + libros.get(i).titulo + " por " + libros.get(i).autor); // Muestra el título y autor de cada libro
                        }
                    }
                    break;

                case 3: // Modificar libro
                    if (biblioteca.listarLibros().isEmpty()) { // Verifica si la lista está vacía
                        System.out.println("No hay libros para modificar.");
                    } else {
                        System.out.print("Índice del libro a modificar: ");
                        int indiceMod = scanner.nextInt(); // Lee el índice del libro a modificar
                        scanner.nextLine(); // Limpiar el buffer
                        System.out.print("Nuevo título: ");
                        String nuevoTitulo = scanner.nextLine(); // Lee el nuevo título
                        System.out.print("Nuevo autor: ");
                        String nuevoAutor = scanner.nextLine(); // Lee el nuevo autor
                        System.out.print("Nuevo precio: ");
                        double nuevoPrecio = scanner.nextDouble(); // Lee el nuevo precio
                        System.out.print("Nuevo año: ");
                        int nuevoAnio = scanner.nextInt(); // Lee el nuevo año
                        scanner.nextLine(); // Limpiar el buffer
                        System.out.print("Nueva ruta de la imagen: ");
                        String nuevaImagen = scanner.nextLine(); // Lee la nueva ruta de la imagen
                        biblioteca.modificarLibro(indiceMod, new Libro(nuevoTitulo, nuevoAutor, nuevoPrecio, nuevoAnio, nuevaImagen)); // Modifica el libro
                    }
                    break;

                case 4: // Eliminar libro
                    if (biblioteca.listarLibros().isEmpty()) { // Verifica si la lista está vacía
                        System.out.println("No hay libros para eliminar.");
                    } else {
                        System.out.print("Índice del libro a eliminar: ");
                        int indiceEliminar = scanner.nextInt(); // Lee el índice del libro a eliminar
                        biblioteca.eliminarLibro(indiceEliminar); // Elimina el libro
                    }
                    break;

                case 5: // Buscar libro
                    if (biblioteca.listarLibros().isEmpty()) { // Verifica si la lista está vacía
                        System.out.println("No hay libros para buscar.");
                    } else {
                        System.out.print("Título del libro: ");
                        String criterio = scanner.nextLine(); // Lee el criterio de búsqueda
                        List<Libro> resultados = biblioteca.buscarLibro(criterio); // Busca libros que coincidan
                        if (resultados.isEmpty()) { // Verifica si hay resultados
                            System.out.println("No se encontraron libros que coincidan con el criterio.");
                        } else {
                            for (Libro libro : resultados) { // Muestra los resultados
                                System.out.println("* " + libro.titulo); // Muestra el título de cada libro encontrado
                            }
                        }
                    }
                    break;

                case 6: // Eliminar todos los libros
                    biblioteca.eliminarTodos(); // Elimina todos los libros
                    System.out.println("Todos los libros han sido eliminados.");
                    break;

                case 7: // Guardar como
                    System.out.print("Introduce la nueva ruta y nombre del archivo: ");
                    String nuevaRuta = scanner.nextLine(); // Lee la nueva ruta del archivo
                    biblioteca.guardarLibros(nuevaRuta); // Guarda los libros en la nueva ruta
                    System.out.println("Datos guardados en: " + nuevaRuta);
                    break;

                case 8: // Salir
                    scanner.close(); // Cierra el Scanner
                    return; // Sale del programa

                default: // Manejo de opciones no válidas
                    System.out.println("Opción no válida.");
            }
        }
    }
}
