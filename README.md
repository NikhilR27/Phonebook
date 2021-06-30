<!-- GETTING STARTED -->
## Built with:
* C# .NET
  * DotNet 5
  * Entity Framework Core 5
  * XUnit
* VueJs 2.X
  * Vuetify
  * axios
* PostgreSQL
* Docker
  * docker-compose   

### Honourable Mentions
* Clean Architecture
* Generic Repository Pattern

## Getting Started
### Prerequisites
1. [Docker](https://www.docker.com/)

## Steps
1. `https://github.com/NikhilR27/phonebook.git`

2. `cd Phonebook`

3. `docker-compose build`

4. `docker-compose up`

5.  Navigate to http://localhost:8000/swagger to view API

6. Navigate to http://localhost:9800 to view UI

## API Endpoints
`GET  /phonebook`

`POST /phonebook`

`GET  /api/phonebook/{id}/entries`

`GET  /api/phonebook/{id}/entries/search/`

`POST /api/phonebook/entry`
