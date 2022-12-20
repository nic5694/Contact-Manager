
# Welcome to the .NET WPF Contact Manager application!

This application allows you to easily manage your contacts by creating, editing, and deleting them. The contacts are stored in a database, so you can access them anytime you need to.

On the main window, you'll find four buttons:

![main window image](screenshots/mainwindow.png)

- Add Contact: Click this button to create a new contact. You can enter their title (like Mr. or Ms.), first and last name, birthday, and up to three different email addresses, phone numbers, and addresses. Only the first name field is necessary, the rest are optional.

![add contact window image](screenshots/newcontact.png)

- Delete Contact: If you need to get rid of a contact, just click this button and select the contact you want to delete. The program will ask you to confirm the deletion of a contact. Deleting only removes a contact from your contact list. It will still exist in your database but will be inactive.

![delete image](https://user-images.githubusercontent.com/57469766/208754491-bd3d7d6c-ac33-4481-8f34-94509e7ce616.png)

- Export: Want to share your contacts with someone else or import them into another app? Click this button to generate a .csv file with all your contacts. A prompt will appear asking you to verify if you want to export all contacts and will ask you to select the location of the export.

![exported csv image](screenshots/export.png)

- Refresh Contacts: If you've made any changes to your contacts and want to see the updated list, click this button to refresh the window.


On the main screen, you will also see a list of all your contacts, along with the date and time each contact was created and last updated. This is helpful for keeping track of any changes you've made to your contacts' information.

If you want to edit a contact in your list, simply double-click the contacts name and the edit window will pop up. Here, you can press the edit buton to change the contacts title, first name, laste name, and birthday.

![edit window image](screenshots/edit.png)

You can also double-click a phone, email or address and it's edit window will pop up as well, allowing you to change the information for every type of entry.

![addressedit image](https://user-images.githubusercontent.com/57469766/208754287-a9368883-566e-450c-b48d-7a5550337f46.png)

The application does not allow the user to enter an email, phone number, or address in a contact without selecting a type, and will also not allow the user to use the same type twice for an entry in a contact (example: two business emails in the same contact).
Upon doing so, the user will recieve a message box error indicating what they should change or do.

![duplicate image](https://user-images.githubusercontent.com/57469766/208755212-bec703bb-3014-40e0-946a-08e3d750360c.png)

Overall, the .NET WPF Contact Manager is a simpe and user-friendly tool for managing your contacts and keeping all their information organized and up-to-date.
