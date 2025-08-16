
package mqtt

import (
    "fmt"
    MQTT "github.com/eclipse/paho.mqtt.golang"
)

func Publish(data string) {
    opts := MQTT.NewClientOptions().AddBroker("tcp://localhost:1883").SetClientID("go_mqtt_client")
    client := MQTT.NewClient(opts)
    if token := client.Connect(); token.Wait() && token.Error() != nil {
        fmt.Println("Error connecting to MQTT broker:", token.Error())
        return
    }

    token := client.Publish("topic/data", 0, false, data)
    token.Wait()
    client.Disconnect(250)
}
