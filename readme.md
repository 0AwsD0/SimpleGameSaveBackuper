# SimpleGameSaveBackupper - it just copies selected folder
## Because Palworld corrupted my save file...
You are free to download the tool and use it for your private porpuses. If you modify this program and you want to share it, make a fork. You have to include link to original repository on the top as shown below: Original repository: [link]

### The program is here: bin\Debug\net6.0-windows | Download only this folder if you don't need sourcecode.
The app is simple as shown in screenshot below.

![Alt text](https://github.com/0AwsD0/SimpleGameSaveBackupper/blob/main/screenshots/1.png "Program Window")

## How to use
1. You can click 'SELECT' buttons to open default windows explorer PATH selector and choose folders or paste PATH to folders manually.
2. Enter time between backups into 3rd input field - in minutes.
3. Click 'SAVE SETTINGS' button and you are ready to go.
4. Click 'MANUAL BACKUP' button and check if the backup was made inside your chosen folder. If not or the app crashed, choose another folder that you have permissions to write into etc. There is no error handling really. The app relays on you not doing crazy stuff.

### The app remembers last chosen options - paths and interval, so you don't have to enter them every time you start the program.

## How it works
The program copies the folder to selected destination. In destination it creates new folder with  same name as selected one adding suffix containing date time. Program does not validate inputs. If you enter 'XD' into interval or 'KAPPA1337' into PATH, than it will crash. It relays on you not doing crazy stuff. The app does not keep track of the number of created folders. You have to delete them manually. Saferst method is to choose what saves you want to delete and do it manually in file explorer.
