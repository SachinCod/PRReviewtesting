
package service

import (
    "go_mqtt_project/internal/db"
    "go_mqtt_project/internal/mqtt"
    "log"
)

func Run() {
    data, err := db.GetData()
    if err != nil {
        log.Fatalf("Failed to get data from DB: %v", err)
    }

    for _, d := range data {
        mqtt.Publish(d)
    }
}
