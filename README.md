FootballHub
Description
This project displays recent football matches and ongoing games using data from the Football Data API. The first page shows a list of the most recent matches, and the system sends requests to the API to fetch match data.

Installation
Clone the repository:
bash
Copy code
git clone https://github.com/hadi-x/FootballHub.git
Navigate to the project directory:
bash
Copy code
cd FootballHub
Install dependencies:
bash
Copy code
dotnet restore
Create a .env file in the project root directory and add your API key:
bash
Copy code
API_KEY=***********
Run the application:
bash
Copy code
dotnet run
Usage
After running the application, the first page will show a list of recent football matches.

Testing
Since the project uses a free API key and sends 7 concurrent requests to the server, you may encounter rate limit errors, causing the server to block requests for about a minute. Please be patient during testing. If necessary, the project could later implement Redis and caching to resolve this issue.

A live sample of the project is available at http://185.73.112.252:1300.

License
This project requires obtaining an API key from Football Data API. There is no other license for this project.

