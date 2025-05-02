using Newtonsoft.Json;
using ProyectoDI___Rick_and_Morty_API.Controllers;
using ProyectoDI___Rick_and_Morty_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Clase de pruebas unitarias para la clase APIService
    /// Contiene pruebas que validan el comportamiento de los métodos que consumen la API pública de Rick and Morty.
    /// Comprobando tanto la obtención de personajes individuales como la recuperación del listado de personajes.
    /// 
    /// NOTAS IMPORTANTES:  ** Estas pruebas realizan llamadas reales a la API pública Rick & Morty.
    ///                     ** Requieren conexión a Internet.
    ///                     ** Pueden fallar si la API está fuera de servicio o cambia su estructura.
    /// </summary>
    public class APIServiceTests
    {

        /// <summary>
        /// Prueba unitaria del método GetPersonajeById().
        /// Verifica que devuelve correctamente un personaje específico (ID = 1).
        /// Comrprueba los datos obtenidos directamente desde la API de Rick and Morty.
        /// </summary>
        /// <returns>Tarea asincrónica que valida el contenido del objeto Personaje.</returns>
        [Fact]
        public async Task GetPersonajeById_ConIdValido_DevuelvePersonajeEsperado()
        {
            // -----------
            // [ Arrange ]
            // -----------

            // Crear una instancia del servicio APIService
            var apiService = new APIService();

            // -------
            // [ Act ]
            // -------

            // Ejecutar el método que se va a probar
            var result = await apiService.GetPersonajeById(1);

            // ----------
            // [ Assert ]
            // ----------

            // Comprobar que el resultado no es nulo y que los datos son los esperados
            Assert.NotNull(result);
            Assert.Equal(1, result.id);
            Assert.Equal("Rick Sanchez", result.name);
            Assert.Equal("Alive", result.status);
            Assert.Equal("Male", result.gender);
        }

        /// <summary>
        /// Prueba unitaria del método GetAllPersonajes() de la clase APIService.
        /// Valida que la llamada a la API pública devuelve una lista no vacía de personajes
        /// y comprueba que los primeros personajes coinciden con los valores esperados
        /// (Rick, Morty y Summer) en nombre, estado y género.
        /// </summary>
        /// <returns>Tarea asincrónica que valida el contenido del objeto ListaPersonajes.</returns>
        [Fact]
        public async Task GetAllPersonajes_ConRespuestaValida_DevuelveListaDePersonajes()
        {
            // -----------
            // [ Arrange ]
            // -----------

            // Crear una instancia del servicio APIService
            var apiService = new APIService();

            // -------
            // [ Act ]
            // -------

            // Ejecutar el método que se va a probar
            var result = await apiService.GetAllPersonajes();

            // ----------
            // [ Assert ]
            // ----------

            // Comprobar que el resultado no es nulo y que contiene los datos esperados
            Assert.NotNull(result);
            Assert.NotEmpty(result.results);

            // Datos del personaje 1 [0]
            Assert.Equal("Rick Sanchez", result.results[0].name);
            Assert.Equal("Alive", result.results[0].status);
            Assert.Equal("Male", result.results[0].gender);

            // Datos del personaje 2 [1]
            Assert.Equal("Morty Smith", result.results[1].name);
            Assert.Equal("Alive", result.results[1].status);
            Assert.Equal("Male", result.results[1].gender);

            // Datos del personaje 3 [2]
            Assert.Equal("Summer Smith", result.results[2].name);
            Assert.Equal("Alive", result.results[2].status);
            Assert.Equal("Female", result.results[2].gender);
        }
    }
}
