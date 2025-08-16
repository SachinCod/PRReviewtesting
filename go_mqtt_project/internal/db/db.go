
package db

import (
    "database/sql"
    _ "github.com/go-sql-driver/mysql"
    "log"
)

func GetData() ([]string, error) {
    db, err := sql.Open("mysql", "user:password@tcp(localhost:3306)/dbname")
    if err != nil {
        return nil, err
    }
    defer db.Close()

    rows, err := db.Query("SELECT data_column FROM data_table")
    if err != nil {
        return nil, err
    }
    defer rows.Close()

    var results []string
    for rows.Next() {
        var data string
        if err := rows.Scan(&data); err != nil {
            log.Println("Error scanning row:", err)
            continue
        }
        results = append(results, data)
    }

    return results, nil
}
