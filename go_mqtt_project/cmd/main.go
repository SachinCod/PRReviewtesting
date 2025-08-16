
package main

import (
    "fmt"
    "go_mqtt_project/internal/service"
)

func main() {
    fmt.Println("Starting the service...")
    service.Run()
}
