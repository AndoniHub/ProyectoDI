
# Rick and Morty API - Aplicación WPF

Aplicación de escritorio desarrollada en C# con WPF (Windows Presentation Foundation), que permite consultar y visualizar personajes de la serie **Rick and Morty** utilizando la API pública oficial.

---

## Descripción

Este es el proyecto final del módulo de **Desarrollo de Interfaces** del ciclo de Desarrollo de Aplicaciones Multiplataforma DAM.
Tiene como objetivo integrar conocimientos de consumo de APIs REST, arquitectura MVVM y desarrollo de interfaces gráficas en entorno Windows .NET.  
La aplicación permite al usuario explorar personajes de la serie, visualizar detalles y mejorar la experiencia mediante un diseño visual limpio y fluido.

---

## Funcionalidades

- Visualización de una lista de personajes obtenidos desde la API.
- Consulta detallada de información al seleccionar un personaje.
- Pruebas unitarias con **xUnit** para asegurar la calidad del código.
- Empaquetado como aplicación ejecutable (.exe) para Windows.

---

## Tecnologías utilizadas

- **Lenguaje principal**: C#  
- **Interfaz de usuario**: XAML con WPF  
- **Arquitectura**: MVVM  
- **Consumo de API**: HttpClient  
- **Pruebas**: xUnit  
- **IDE**: Visual Studio 2022  
- **Control de versiones**: Git + GitHub  

---

## Estructura de los proyectos

### Rick and Morty API
- `Assets/` – Imágenes y recursos utilizados en la aplicación.
- `Models/` – Clases de datos que representan los personajes.
- `Services/` – Servicios para la comunicación con la API (RickAndMortyAPIService).
- `Styles/` – Estilos y recursos de la interfaz de usuario (colores, controles y fuentes).
- `ViewModels/` – Lógica de presentación (MainViewModel).
- `Views/` – Vistas de la interfaz de usuario (MainWindow y DetallePersonaje).

### xUnit Tests
- `/` – Proyecto de pruebas con xUnit.

---

## Instalación y ejecución

1. **Clonar el repositorio.**

2. **Abrir el proyecto** en Visual Studio.

3. **Compilar y ejecutar** el proyecto.

   > Alternativamente, puedes descargar el paquete ejecutable desde la sección [Releases](https://github.com/AndoniHub/ProyectoDI/releases/tag/v1.0.0).

---

## Pruebas

El repositorio incluye un proyecto de pruebas con **xUnit**, que verifica:

- El correcto funcionamiento del servicio de consumo de la API (`APIServiceTests`).
- La lógica del ViewModel (`MainViewModelTests`), incluyendo la carga y gestión de personajes.

---

## Requisitos

- Sistema operativo: Windows 10 o superior
- Conexión a Internet (para acceder a la API)
- No se requieren instalaciones adicionales: la app se ha publicado como ejecutable autónomo.

---

## Release

- Última versión: `v1.0.0`
- Tipo: Ejecutable autónomo para Windows
- [Descargar release](https://github.com/AndoniHub/ProyectoDI/releases/tag/v1.0.0)

---

## Notas

> Durante la integración de las pruebas en el repositorio principal, surgieron conflictos con el historial. Por ello, se creó un nuevo repositorio público con ambos proyectos integrados.
El repositorio original se conserva como referencia de la evolución mediante los commits.
[Repositorio original](https://github.com/AndoniHub/ProyectoDI---Rick-and-Morty-API)

---

## Licencia

Este proyecto ha sido desarrollado con fines educativos y no tiene fines comerciales.

---
