using Newtonsoft.Json;
using ProyectoDI___Rick_and_Morty_API.Controllers;
using ProyectoDI___Rick_and_Morty_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTests
{
    /**
     * Editado archivo Proyecto.csproj para asegurar compatibilidad de versiones entre proyectos
     * ORIGINAL -> <TargetFramework>net8.0</TargetFramework>
     * MODIFICADO -> <TargetFramework>net7.0</TargetFramework>
     */

    /**
     * Arrange -> Preparar los objetos y el entorno para la prueba
     * Act -> Ejecutar el método que se va a probar
     * Assert -> Comprobar que el resultado es el esperado
     */

    public class APIServiceTests
    {
        

        [Fact]
        public async Task GetPersonajeById_ReturnsExpectedPersonaje()
        {
            // ----------------------------------------------------------------------------------------------------------
            // Arrange
            // ----------------------------------------------------------------------------------------------------------
            // Crear instancia del personaje con los datos que se esperan obtener
            var personajeEsperado = new Personaje { id = 1, name = "Rick Sanchez" };
            // Convertir el personaje a JSON
            var personajeJson = JsonConvert.SerializeObject(personajeEsperado);

            // Crear un manejador de mensajes HTTP simulado
            var handlerMock = new FakeHttpMessageHandler(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK, // Simular una respuesta exitosa
                Content = new StringContent(personajeJson) // Cuerpo del mensaje con el JSON del personaje
            });

            // Crear una instancia de HttpClient con el manejador simulado
            var httpClient = new HttpClient(handlerMock);

            // Crear una instancia del servicio APIService con el cliente simulado
            var service = new APIService();

            // ----------------------------------------------------------------------------------------------------------
            // Act
            // ----------------------------------------------------------------------------------------------------------
            var result = await service.GetPersonajeById(1);

            // ----------------------------------------------------------------------------------------------------------
            // Assert
            // ----------------------------------------------------------------------------------------------------------
            Assert.NotNull(result);
            Assert.Equal("Rick Sanchez", result.name);
            Assert.Equal(1, result.id);
        }

        // Clase interna para simular el comportamiento de HttpClient
        public class FakeHttpMessageHandler : HttpMessageHandler
        {
            private readonly HttpResponseMessage _response;

            public FakeHttpMessageHandler(HttpResponseMessage response)
            {
                _response = response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_response);
            }
        }
    }
}
