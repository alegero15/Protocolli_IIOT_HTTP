using NetCoreClient.Sensors;
using NetCoreClient.Protocols;

// define sensors
List<ISensorInterface> sensors = new();
sensors.Add(new VirtualSpeedSensor());
sensors.Add(new VirtualMoveSensor());

List<ISensorInterface2> sensors2 = new();
sensors2.Add(new VirtualSpeedSensor2());

int count = 1;

// define protocol
ProtocolInterface protocol = new Http("https://58db-185-122-225-105.ngrok-free.app/cars/1/metrics");

// send data to server
while (true)
{
    foreach (ISensorInterface sensor in sensors)
    {
        //PRIMA MACCHINA, SENSORE VELOCITA
        if (count == 1)
        {
            var sensorValueSpeed = sensor.ToJson();

            protocol.Send("First Sensor Speed " + sensorValueSpeed);

            Console.WriteLine("First Sensor Speed: " + sensorValueSpeed);

            count = 0;
        }

        //PERIMA MACCHINA, SENSORE MOVIMENTO, IO HO FATTO CON VALORI RANDOMICI COME PER LA VELOCITA, BASTA AGGIUENGERE I VALORI X,Y,Z IN CARTESIANO
        if (count == 0)
        {
            var sensorValueSpeed = sensor.ToJson();

            protocol.Send("First Sensor Move " + sensorValueSpeed);

            Console.WriteLine("First Sensor Move: " + sensorValueSpeed);
            count = 1;
        }
        Thread.Sleep(1000);
    }
    //    foreach (ISensorInterface2 sensor_2 in sensors2) //SECONDA MACCHINA, SENSORE VELOCITA, FATTO PER PROVA
    //    {
    //        var sensorValueSpeed2 = sensor_2.ToJson();

    //        protocol.Send("First Sensor Speed " + sensorValueSpeed2);

    //        Console.WriteLine("First Sensor Speed: " + sensorValueSpeed2);

    //    }
    //Thread.Sleep(1000);


}

