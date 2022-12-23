## TaskTracker

![image](https://user-images.githubusercontent.com/69454511/209300673-26abe3fc-d79a-4d43-9733-98f6b69dc050.png)

TaskTracker is a WEB API that provides:
- Ability to create / view / edit / delete information about projects
- Ability to create / view / edit / delete information about tasks
- Ability to add and remove tasks from a project (one project can contain several tasks)
- Ability to view all tasks in the project

## Instalation

1. `cd` to solution directory. Run  `docker compose  up`<br>
   by default swagger will be avaliable on http://localhost:8000/swagger/index.html<br>
   you can change this in docker-compose.yml
   
2. run through Kestrel. For using this variant provide correct connection string in appsettings.json<br>
   by default swagger will ba avaliable on http://localhost:5000/swagger/index.html<br>
    you can change this in launchSettings.json
    
## License

[MIT](https://choosealicense.com/licenses/mit/)
