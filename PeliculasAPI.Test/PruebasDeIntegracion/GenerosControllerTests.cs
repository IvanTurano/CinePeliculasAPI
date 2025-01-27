﻿using Newtonsoft.Json;
using PeliculasAPI.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using PeliculasAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Test.PruebasDeIntegracion
{
    [TestClass]
    public class GenerosControllerTests : BasePruebas
    {
        private static readonly string url = "/api/generos";

        [TestMethod]
        public async Task ObtenerTodosLosGenerosListadoVacio()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreBD);

            var cliente = factory.CreateClient();
            var respuesta = await cliente.GetAsync(url);

            respuesta.EnsureSuccessStatusCode();

            var generos = JsonConvert.DeserializeObject<List<GeneroDTO>>(await respuesta.Content.ReadAsStringAsync());

            Assert.AreEqual(0,generos.Count());
        }

        [TestMethod]
        public async Task ObtenerTodosLosGeneros()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreBD);

            var contexto = ConstruirContext(nombreBD);
            contexto.Generos.Add(new Genero() { Nombre = "accion" });
            contexto.Generos.Add(new Genero() { Nombre = "aventura" });
            await contexto.SaveChangesAsync();

            var cliente = factory.CreateClient();
            var respuesta = await cliente.GetAsync(url);

            respuesta.EnsureSuccessStatusCode();

            var generos = JsonConvert.DeserializeObject<List<GeneroDTO>>(await respuesta.Content.ReadAsStringAsync());

            Assert.AreEqual(2, generos.Count());
        }

        [TestMethod]
        public async Task BorrarGenero()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreBD);

            var contexto = ConstruirContext(nombreBD);
            contexto.Generos.Add(new Genero() { Nombre = "accion" });
            await contexto.SaveChangesAsync();

            var cliente = factory.CreateClient();
            var respuesta = await cliente.DeleteAsync($"{url}/1");
            respuesta.EnsureSuccessStatusCode();

            var contexto2 = ConstruirContext(nombreBD);
            var existe = await contexto2.Generos.AnyAsync();
            Assert.IsFalse(existe);
        }

        [TestMethod]
        public async Task BorrarGeneroRetorna401()
        {
            var nombreBD = Guid.NewGuid().ToString();
            var factory = ConstruirWebApplicationFactory(nombreBD,false);

            var cliente = factory.CreateClient();
            var respuesta = await cliente.DeleteAsync($"{url}/1");
            Assert.AreEqual("Unauthorized", respuesta.ReasonPhrase);

        }
    }
}
