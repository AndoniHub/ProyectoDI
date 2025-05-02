using RickAndMortyAPI.Models;
using RickAndMortyAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * ----------------------------------------------------------------------------------------------------------------
 * [ NOTA 1: Configuración del proyecto de pruebas unitarias ]
 * Editado archivo Proyecto.csproj para asegurar compatibilidad de versiones entre proyectos
 * ORIGINAL -> <TargetFramework>net8.0</TargetFramework>
 * MODIFICADO -> <TargetFramework>net7.0</TargetFramework>
 * 
 * [ NOTA 2: Convención de nombres para las pruebas unitarias ]
 * Se utiliza la convención más extendida en entornos .NET y xUnit -> Método_Escenario_ResultadoEsperado
 * 
 * [ NOTA 3: Estructura de las pruebas unitarias ]
 * ARRANGE  -> Preparar los objetos y el entorno para la prueba
 * ACT      -> Ejecutar el método que se va a probar
 * ASSERT   -> Comprobar que el resultado es el esperado
 * ----------------------------------------------------------------------------------------------------------------
 */

namespace xUnit_Tests
{
    /// <summary>
    /// Clase de pruebas unitarias para el ViewModel MainViewModel.
    /// Contiene pruebas que validan el comportamiento de los métodos de la clase MainViewModel.
    /// 
    /// NOTAS IMPORTANTES:  ** Estas pruebas realizan llamadas reales a la API pública Rick & Morty.
    ///                     ** Requieren conexión a Internet.
    ///                     ** Pueden fallar si la API está fuera de servicio o cambia su estructura.
    /// </summary>
    public class MainViewModelTests
    {

        /// <summary>
        /// Prueba unitaria del método CargarPersonajes().
        /// Verifica que se carga la lista de personajes correctamente.
        /// Comprueba el nombre de los 3 primeros personajes de la lista.
        /// </summary>
        [Fact]
        public async Task CargarPersonajes_ConConexionExitosa_CargaListaDePersonajes()
        {
            // ----------- 
            // [ Arrange ]
            // -----------

            // Crear una instancia de MainViewModel
            var mainViewModel = new MainViewModel();

            // ------- 
            // [ Act ] 
            // -------

            // Ejecutar la carga de personajes
            await mainViewModel.CargarPersonajes();

            // ---------- 
            // [ Assert ] 
            // ----------

            // Comprobar que se han cargado personajes
            Assert.NotEmpty(mainViewModel.Personajes);

            // Comprobar los nombres de los 3 primeros personajes
            Assert.Equal("Rick Sanchez", mainViewModel.Personajes[0].name);
            Assert.Equal("Morty Smith", mainViewModel.Personajes[1].name);
            Assert.Equal("Summer Smith", mainViewModel.Personajes[2].name);
        }

        /// <summary>
        /// Prueba unitaria del método ActualizarImagen().
        /// Prueba que al establecer un personaje como seleccionado,
        /// la propiedad ImagenSeleccionada se actualice correctamente con su imagen.
        /// </summary>
        [Fact]
        public void ActualizarImagen_PersonajeSeleccionado_ActualizaImagenSeleccionadaCorrectamente()
        {
            // ----------- 
            // [ Arrange ]
            // -----------

            // Crear un personaje de prueba con una URL de imagen válida
            var personaje = new Personaje
            {
                id = 1,
                name = "Rick",
                image = "https://rickandmortyapi.com/api/character/avatar/1.jpeg"
            };

            // Crear una instancia del MainViewModel
            var mainViewModel = new MainViewModel();

            // ------- 
            // [ Act ] 
            // -------

            // Simular la selección de personaje
            // Asignar el personaje simulado a la propiedad PersonajeSeleccionado
            mainViewModel.PersonajeSeleccionado = personaje;

            // Llamar al método que actualiza la imagen
            mainViewModel.ActualizarImagen();

            // ---------- 
            // [ Assert ] 
            // ----------

            // Verificar que ImagenSeleccionada no sea nula (se ha cargado una imagen)
            Assert.NotNull(mainViewModel.ImagenSeleccionada);

            // Verificar que la URL de la imagen contiene el nombre del archivo correcto
            Assert.Contains("avatar/1.jpeg", mainViewModel.ImagenSeleccionada.UriSource.ToString());
        }
    }
}
