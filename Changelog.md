# Changelog

## 2. Aspire init

### How to

#### Visual Studio

- Rechtsklick aufs Projekt --> Hinzufügen --> Aspire-Orchestrator

#### VSCode

- `dotnet new aspire-apphost`
- `dotnet new aspire-servicedefaults`
- GraphQl-Projekt als Projektabhängigkeit in den apphost holen
- `builder.AddServiceDefaults();` im GraphQl-Projekt

Danach immer das AppHost-Projekt starten. Der ConnectionString kann dann immer aus dem AppHost kommen

### Was ist neu?

- Aspire Dashboard
- zentrale Stelle für Logs, Konfiguration (wo nötig) und Traces

## 1. Graphql init

Wir bauen als Grundlage einen kleinen Service mit GraphQl-API

### How to

- `dotnet new graphql`
- Solution anlegen
- Entity Framework DbContext anlegen für die Datentypen der API
- erste Migration anlegen

### Probleme

- wo ist meine Datenbank?
- wie kommt ein neuer Entwickler schnell auf eine lauffähige Umgebung?
- welche Abhängigkeiten hat meine Anwendung?
- wie kann ich automatisch eine Datenbank mit meiner Anwendung bereitstellen?
- wie verfolge ich Abläufe und Logs der Anwendung und der Datenbank?
- vertrauliche Zugangsdaten?
