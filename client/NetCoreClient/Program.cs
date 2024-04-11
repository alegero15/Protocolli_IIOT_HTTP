using NetCoreClient.Sensors;
using NetCoreClient.Protocols;
using System.Reflection;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// define sensors
List<ISensorInterface> sensors = new();
sensors.Add(new VirtualSpeedSensor());
sensors.Add(new VirtualMoveSensor());

List<ISensorInterface2> sensors2 = new();
sensors2.Add(new VirtualSpeedSensor2());
int count = 1;


// define protocol
ProtocolInterface protocol = new Http("https://dd18-185-122-225-105.ngrok-free.app/cars/1/metrics");

// send data to server
while (true)
{
    foreach (ISensorInterface sensor in sensors)
    {
        //PRIMA MACCHINA, SENSORE VELOCITA

        var speedSensor = sensors.FirstOrDefault(s => s is VirtualSpeedSensor);
        var moveSensor = sensors.FirstOrDefault(s => s is VirtualMoveSensor);

        if (speedSensor != null && moveSensor != null)
        {
            var speedJson = speedSensor.ToJson();
            var moveJson = moveSensor.ToJson();
            JArray moveArray = JArray.Parse(moveJson);

            //var firstValue = moveJson[1];
            //var secondValue = moveJson[3];
            //var thirdValue = moveJson[5];

            var firstValue = (int)moveArray[0]; // Accedi al primo valore: 12
            var secondValue = (int)moveArray[1]; // Accedi al secondo valore: 15
            var thirdValue = (int)moveArray[2]; // Accedi al terzo valore: 2

            // Puoi quindi utilizzare questi valori come desiderato
            //Console.WriteLine("Primo valore: " + firstValue);
            //Console.WriteLine("Secondo valore: " + secondValue);
            //Console.WriteLine("Terzo valore: " + thirdValue);

            //le come il diesel ga da scaldarse

            // Creazione del messaggio combinato con un separatore
            var combinedMessage = $"{speedJson},{firstValue},{secondValue},{thirdValue}";

            // Invio del messaggio tramite il protocollo
            protocol.Send(combinedMessage);
            Console.WriteLine(combinedMessage);
        }
        Thread.Sleep(5000);


        //! SAREBBE DA MANDARE UN UNICO PACCHETTO, MA LASCIAMO L'INVIO SINGOLO
        //foreach (ISensorInterface2 sensor_2 in sensors2) //SECONDA MACCHINA, SENSORE VELOCITA, FATTO PER PROVA
        //{
        //    var sensorValueSpeed2 = sensor_2.ToJson();
        //    protocol.Send("-------");
        //    protocol.Send("Second Sensor Speed " + sensorValueSpeed2);
        //}
    }

}

