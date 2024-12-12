


using L01_Domain.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L02_Persistence
{
    public class RepositorioPacientesFake : IRepositorioPacientes

    /// <summary>
    /// Busca un  paciente en el repositorio de datos
    /// </summary>
    /// <returns>
    /// El paciente que correponde con el id dado
    /// </returns>
    /// <exception cref="L01_Domain.Paciente.PacienteNoEncontradoException">Lanza la excepcion
    /// en caso de no encontrar al paciente.</exception>
    /// <param name="idPaciente">Una cadena con la identificación del paciente</param>
    {
        public IPacienteCita GetPaciente(int idPaciente)
        {
            List<Paciente> pacientes;

            String jsonString = FakeDB.TablaPacientes.ToJSON();
            pacientes = System.Text.Json.JsonSerializer.Deserialize<List<Paciente>>(jsonString);

            IPacienteCita paciente = pacientes.FirstOrDefault(p => p.DocumentoId == idPaciente);
            if (paciente is null)
            {
                throw new PacienteNoEncontradoException("El Paciente con Id-->"+idPaciente+", no esta registrado");
            }
                 
            return paciente;

        }

       
    }
}
