using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Globalization;

// Ejemplo de uso:
/* 
    Metricas.Instance.IniciarSesion("sesion_003");
    Metricas.Instance.RegistrarEvento("Monedas", 20);
    Metricas.Instance.RegistrarEvento("TiempoJugado", 135.7f);
    Metricas.Instance.RegistrarEvento("Saltos", 1);

    // Guardar manualmente
    Metricas.Instance.Guardar();
*/

// Resultado del csv

/* 
    sessionId, Monedas, TiempoJugado, Saltos
    sesion_001,10,123.4,25
    sesion_002,15,99.8,30
    sesion_003,20,135.7,42
*/


public class Metricas : MonoBehaviour
{
    // Creamos la clase como un singleton para usar en cualquier lugar del juego.
    public static Metricas Instance { get; private set; }

    // ID actual de la sesión -> para que registremos la data de cada sesión bajo un id
    private string currentSessionId;

    // Diccionario nombre de evento / valor
    private Dictionary<string, float> eventosActuales = new();


    private string rutaCSV;

    private void Awake()
    {
        // EL singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        // Application.persistentDataPath es la ruta de persistencia de datos que ofrece unity, depende de cada SO
        // Los datos se guardarán en el archivo "....ruta/metricas.csv"
        rutaCSV = Path.Combine(Application.persistentDataPath, "metricas.csv");
        Debug.Log("Metricas en: " + rutaCSV);
        // Para MAC: /Users/nacho/Library/Application Support/DefaultCompany/Metricas
    }

    // Inicia una nueva sesión con un ID (Esto se debería llamar al iniciar el juego o la sesión)
    public void IniciarSesion(string sessionId = "")
    {
        if (sessionId == "") // Si no hay un session id, va a usar de id la fecha y hora del momento de invocar el método
        {
            System.DateTime now = System.DateTime.Now;
            currentSessionId = now.ToString();
        }
        else
        {
            currentSessionId = sessionId;
        }


        eventosActuales = new Dictionary<string, float>();
    }

    // Registra o actualiza un evento
    public void RegistrarEvento(string nombreEvento, float valor)
    {
        if (string.IsNullOrEmpty(currentSessionId))
        {
            Debug.LogWarning("⚠️ No hay sesión activa. Usa IniciarSesion(sessionId) antes de registrar eventos.");
            return;
        }

        if (eventosActuales.ContainsKey(nombreEvento))
            eventosActuales[nombreEvento] += valor; // En caso de que el evento ya exista, el valor se acumula
        else
            eventosActuales[nombreEvento] = valor; // en caso de que no exista, se registra por primera vez
    }

    // Obtiene el valor de un evento en la sesión actual
    public float ObtenerValor(string nombreEvento)
    {
        if (!eventosActuales.ContainsKey(nombreEvento))
            return 0f;

        return eventosActuales[nombreEvento];
    }

    // Guarda los datos actuales en el archivo CSV (una fila por sesión)
    public void Guardar()
    {
        if (string.IsNullOrEmpty(currentSessionId))
        {
            Debug.LogWarning("No hay sesión activa. No se puede guardar métricas.");
            return;
        }

        try
        {
            List<Dictionary<string, string>> filas = new();
            HashSet<string> headers = new() { "sessionId" };

            if (File.Exists(rutaCSV))
            {
                string[] lineas = File.ReadAllLines(rutaCSV);
                if (lineas.Length > 0)
                {
                    var encabezados = lineas[0].Split(',').ToList();
                    foreach (var h in encabezados)
                        headers.Add(h);

                    for (int i = 1; i < lineas.Length; i++)
                    {
                        var valores = lineas[i].Split(',');
                        var fila = new Dictionary<string, string>();
                        for (int j = 0; j < encabezados.Count && j < valores.Length; j++)
                            fila[encabezados[j]] = valores[j];
                        filas.Add(fila);
                    }
                }
            }

            foreach (var e in eventosActuales.Keys)
                headers.Add(e);

            var nuevaFila = new Dictionary<string, string> { ["sessionId"] = currentSessionId };
            foreach (var kv in eventosActuales)
                nuevaFila[kv.Key] = kv.Value.ToString("0.##", CultureInfo.InvariantCulture);
            filas.Add(nuevaFila);

            StringBuilder sb = new();
            var headersOrdenados = headers.ToList();
            sb.AppendLine(string.Join(",", headersOrdenados));

            foreach (var fila in filas)
            {
                List<string> valores = new();
                foreach (var header in headersOrdenados)
                {
                    fila.TryGetValue(header, out string val);
                    valores.Add(val ?? "");
                }
                sb.AppendLine(string.Join(",", valores));
            }

            File.WriteAllText(rutaCSV, sb.ToString(), Encoding.UTF8);

            Debug.Log($"Métricas guardadas correctamente en: {rutaCSV}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error al guardar métricas CSV: {e.Message}");
        }
    }

    // Guarda automáticamente al cerrar el juego
    private void OnApplicationQuit()
    {
        Guardar();
        Debug.Log("Guardado");
    }

}