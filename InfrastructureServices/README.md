# 🛠️ Setup Guide for `sln` Data Directory

This guide walks you through setting up the `sln` data directory, granting necessary permissions, and starting your Docker services successfully. The directory is used to persist data for services such as MongoDB, Redis, Kafka, Elasticsearch, Mysql etc.

---

## 📂 Step 1: Move `sln` Directory to `/home`

From the location where the `sln` folder currently exists, run:

```bash
sudo mv ./sln /home/
```

## 🔐 Step 2: Grant Full Permissions

To ensure Docker and all services can read from and write to the `sln` directory, you need to grant full access permissions.

Run the following command:

```bash
sudo chmod -R 777 /home/sln
```

## 🧹 Step 3: Clean Up MySQL Data Folder (Important)

Before starting Docker for the first time, remove any README or placeholder files that may exist in the MySQL data folder.
```bash
sudo rm -f /home/sln/data/mysql/README
```

## 🔐 Step 4: Grant Full Permissions Mysql
Run the following command:
```bash
docker exec -it mysql mysql -u root -p
```

```bash
GRANT ALL PRIVILEGES ON *.* TO 'esg'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;
```
