# LawProject
Law project is a Interactive Law Firm Automation and Management System. People in the field of law will benefit from this application.  This project was developed using N-Layer Architecture and AOP.

</br></br> 

### Project Document
[embed]https://github.com/RamazanHalid/LawProject/files/8835367/Senior.Project.Medilaw.Ramazan.Halid.-.Samin.Taheri.pdf[/embed]

The Register page was the first page created in this application. Users must enter information such as their name, title, cellphone, email, country, city, and password on this page. All this information is validated using “yup,” a JavaScript schema builder for value parsing and validation. The city option in the register form is displayed according to the selection of the country. After the user enters all this information and presses the “Sign Up!” button, it first performs a validation control of the password and confirm password equality. In case any error occurs, an error popup that has been imported and integrated as a component will appear and display the error to the users. If there are no problems, a loader will be displayed in the button to show the users the improvements of the process. Once completed, as shown in the second figure, a success pop up will appear to show the users that the process was successful, and the user will be registered to the system and directed to the login page. There is also an option on the top right corner of the page to redirect the users to the login page in case they already have an account.
The user interface of this page is depicted in the first image.
 

 ![image](https://user-images.githubusercontent.com/42031794/177732724-7ab13a0a-8001-4c56-a1f0-e8c5b17e6e20.png)
 </br>
 </br>
 Figure 1:
  </br>
 </br>
![image](https://user-images.githubusercontent.com/42031794/177732791-c9afecab-20b8-4e27-847c-dd3ededb51d9.png)
 </br>
 </br>
Figure 2:
 </br>
 </br>
•	Login, Approve Account pages:
After user registers to the system, he/she will be directed to the login page where he/she will confirm his/her account since it is the first time the user will use the system. First as shown in the third figure, once the user enters his/her cellphone number and password and presses the login button, an approvement code will be sent via SMS to confirm his/her account. In the next step, as shown in the fourth figure, the user will be directed to the account approvement page and once they enter their phone number along with the approvement code sent to their cellphone number, as shown in the fifth figure a success pop up will appear which shows that they have been approved their account successfully. In the next step the users will be directed to the login page again to approve their email this time. After they enter their cellphone which has been approved along with their password, a pop up will appear that says they should approve their email address as well. In this step, the users would have to check their email inboxes and they will be able to approve their email address by clicking on the email sent from MediLaw. In this step which the user has been approved his/her cellphone number and email account, he/she will be able to successfully login to the system. After the user enters the cellphone number and password and clicks the “login” button a loader will be displayed in the button to show the users the improvements of the process and after that, a success pop up will appear to show the users they have been logged in to the system successfully.
![image](https://user-images.githubusercontent.com/42031794/177733027-887fe749-c854-449c-ba31-18ecb5187b1f.png)
Figure 3:
![image](https://user-images.githubusercontent.com/42031794/177733047-d7cbfac0-9ac6-4e0d-8799-dd130187715a.png)
Figure 4:
 ![image](https://user-images.githubusercontent.com/42031794/177733102-c04c1521-ab85-48a0-b143-2cb7b60d14c8.png)
Figure 5:

•	Forgot password page:
In the login page, there exists a “forgot password?” option, in case the user forgot his/her password which navigated the user to the forgot password page as shown in the sixth figure. Once the user has entered his/her cellphone number, as shown in the seventh figure, a pop up will appear that shows a code has been sent to his/her cellphone. In the next step, as shown in the eighth figure, the users will be navigated to the change password page where the user can change his/her password by entering his/her cellphone number and his/her new password two times. A validation control is also performed in case the two passwords don’t match each other.

 ![image](https://user-images.githubusercontent.com/42031794/177733168-f708dfbf-8332-4804-a9ef-cd6a47ac2b40.png)
Figure 6:
 ![image](https://user-images.githubusercontent.com/42031794/177733193-5bfbc06e-962e-4aa1-8a2b-7ccb4df9595e.png)

Figure 7:
![image](https://user-images.githubusercontent.com/42031794/177733215-4098ca2b-7a6c-4612-8d00-c2b00b87d73f.png)
 
Figure 8:

•	Licence page:
Users will be able to perform actions in this application by owning a licence, which is a way of describing the authorization to perform certain actions in this application. After users log into the system for the first time, a licence is automatically created for them based on the information shown in the ninth figure. There are two cards on this page: one to show the licences created by the user as well as the licence that was created automatically, and the other to show the licences that the user has been registered in, which will be explained later. When the user selects one of these licenses, he or she will be able to access the home page (dashboard).
![image](https://user-images.githubusercontent.com/42031794/177733255-a0fcd58a-ebbc-43ef-90e3-da94abb97e9b.png)
 
Figure 9:

•	Dashbaosrd:
The first option in the sidebar which is dashboard displays the users' upcoming five events as well as statistics for each user's connected clients, connected tasks, connected events, and connected cases. Since the user will have no upcoming events when he or she first logs into the system, a message will be displayed saying, "Please Add Event."
•	Header (Profile, Connected Licences, Support, Notifications):
The panel consists of a header which is depicted in figure 11. The header includes an account popover that initially displays the user's name, surname, and email address. Then there exist some options for linking the user to specific pages, and finally, there is a logout button to assist users in logging out of the system. The first option takes the user to the home (dashboard), while the second takes the user to the profile page, as shown in Figure 13. The user will be able to view and update his or her information on this page, as well as select an avatar as their profile picture. The third option, as shown in Figure 14, takes users to the "connected licences" page, where they can accept or decline a licence that other users requested in the add user section, which will be explained shortly. And lastly the fourth option is the admin panel which only admins can see since there exists a claim that has permissions only for the administrators. 
The second header property is the notification option, which displays notifications as shown in Figure 12. When users click the notification button, all notifications are marked as read; however, users can delete any notification by clicking the trash icon on each notification.
The support option is another feature in the header, as shown in Figure 15. Users can seek assistance from administrators on this page by typing their messages in the text field and clicking the send button. If the administrator sees the messages, the messages will be marked as read; otherwise, they will be marked as unread. There is also a refresh button to refresh the messages if necessary.
![image](https://user-images.githubusercontent.com/42031794/177733285-64dd27b0-6f34-450e-b5e1-d2a698aea51a.png)
 
Figure 10:
![image](https://user-images.githubusercontent.com/42031794/177733329-f0bea28d-451d-49c6-9822-2240a1371335.png)
     
Figure 11:
![image](https://user-images.githubusercontent.com/42031794/177733368-1ea87952-82d2-484f-846f-2866503d3085.png)

Figure 12:
![image](https://user-images.githubusercontent.com/42031794/177733392-bdac34ee-6a0a-4531-abe8-415c3eecadd7.png)
 
Figure 13:
![image](https://user-images.githubusercontent.com/42031794/177733428-2dcf1176-64e5-4312-86c6-03ad4ad01cf2.png)
 
Figure 14:
![image](https://user-images.githubusercontent.com/42031794/177733440-0e3f643e-2b86-4fb7-a15c-6ad936df1f86.png)
 
Figure 15:

•	Sidebar:
The second feature of the panel is the sidebar. The sidebar contains the logo, a box displaying the licence that users have logged in with, sidebar configurations, and a button that takes users to the landing page.
•	Licence settings page:
As shown in Figure 16, the box that displays the licence name is clickable and takes users to the "licence setting" page. This page contains a list of important information for lawyers, such as continuing tasks, clients, cases, transaction activities, current balance, currently used disk space (to keep track of space used after uploading files for cases), number of current users, and SMS. The following section of this page consists of some buttons that direct users to various sections with specific purposes.

The first button, "Users," takes users to a page, as shown in Figure 17, where each user can add users by sending them a request, and the user who has been sent the request will be able to accept the request in the “connected licence” section, which will then be listed in the "registered licences" section of the "licence" page. The user will be able to search for the numbers he/she wants to add by typing the first four digits of the cellphone number, and the sys![image](https://user-images.githubusercontent.com/42031794/177733460-11cd306e-d01a-4d74-a2dd-42a1ecaefcdf.png)tem will automatically list the users whose first four digits have been searched. The corresponding code for this section is also shown in figure 18, in which an empty list is first created, and then if the number searched by the user has a length greater than a length 3, the users to be displayed are equal to the created new list, and the new list is filtered by the filter function, that filters the searched numbers using the startsWith() method, which returns true or false if the string starts with that character or not, and finally the new list is returned.
In the occasion that no user is found, a message will be displayed as shown in the figure 19. After the user sends the request to the corresponding user, a success popup message will be displayed to the users, as shown in figure 20, and the list will be updated accordingly.

Figure 16:
 
Figure 17:
 
Figure 18:

 
Figure 19:

 
Figure 20:
As seen in the figure 21, the second button in the “Licence Settings” page “Add Balance”, will navigate the users to the balance page where users can add balance to their credit card. After adding a balance, a pop up will appear asking users whether they want to save their information for later use or not, which can then be used as a drop down in the credit card reminder option, as shown in figure 22. For the next append operations, users could choose between credit cards for convenience or "none," which clears the text fields. There also exists a button at the top of the page as can be seen in the figure 23, which when clicked, opens a modal to edit credit card information that has been selected via the credit card reminder option. Also, must be mentioned that all the modals in this application are programmed to prevent any closing when clicking the area around the modal and to ensure the modal closes only after clicking the close icon on the top right corner of the modal, by setting the “hidebackdrop” and “disableEscapeKeyDown” options of the modal component to true. After users submit the form, if the operation is successful, a success message will be displayed as shown in the figure 24 and an error message otherwise.

 
Figure 21:
 
Figure 22:
 
Figure 23:
 
Figure 24:

The third button on the "Licence Settings" page, as shown in figure 25, is the user list page, where each user can grant permission to other users if they have the required authorization; otherwise, the button will be disabled, indicating that the user is awaiting authorization. When a user clicks the "give permission" button, the selected user's id is collected at the end of the URL, as shown in figure 26, and the selected user's corresponding data is listed in the permission page, as shown in figure 27. On this page, the user can grant or revoke the selected user's permissions by checking and unchecking the check boxes and saving the changes by clicking the "save the changes" button.
 
Figure 25:
 
Figure 26:
 
Figure 27:

The fourth button on the "Licence Settings" page, as shown in figure 28, is the "SMS package" option, which when clicked opens a modal with information about the SMS package and a purchase button. When the button is clicked, a success message appears to inform users that the operation was successful.
 
Figure 28:

The fifth button on the "Licence Settings" page, as shown in figure 29, is the "Add licence" option, which when clicked opens a modal in which users can add licence by filling in the required text areas and clicking the "add" button.

 
Figure 29:

The sixth button on the "Licence Settings" page, as shown in figure 30, is the "Edit licence" option, which when clicked opens a modal in which users can edit their license by changing the text areas and clicking the "edit" button.
 
Figure 30:

Last but not least, as shown in figure 31, the seventh button on the "Licence Settings" page, is the “payment history” option which when clicked will display the payment history information of the corresponding user which includes the amount and the payment day.

 
Figure 31:

•	Definitions page (Case Status, Case Type, Court Offices, Transaction Activity Subtype, Task Type, Process Type):
The second option in the sidebar, "Definitions," as shown in Figure 32, includes the necessary options that will be used throughout the application. The first definition option is "case status," as shown in figure 33. 
In this page, the users can add, edit, and change the activity of the case statuses. The add operation can be performed by clicking the “new record” button at the top right corner of the page. As shown in the figure 34, the users will be able to add a new record by typing a name, selecting a court office type and a status for their case status. To improve usability, the "autofocus" option has been added to the first text field of each modal. In case there are any issues with adding or editing a record, an alert message including the error message such as the length of the character must be at least two characters long will be displayed at the bottom of the modal, as shown in figure 35. After the operation is done, if the process is successful, a success popup will appear, and the list will be updated accordingly. Each case status will have a "edit" option, which when clicked will display each record's individual information and allow users to edit their records as well as a "change activity" option where users can toggle the switch to toggle the status of each case between "active" and "passive," as shown in figure 33. Once the user changes the activity by toggling the switch, a success message will be displayed to prevent the service from crashing. There is also a filter option that allows users to filter the case statuses by the court office type and the status of the case statuses. As shown in Figure 36, this operation is carried out by creating a usestate() hook for each option and then filtering each object using the filter() function. Following that, the created hooks will be retrieved from the value property and set in the onchange property of each text field area.

 
Figure 32:
 
Figure 33:
 
Figure 34:
 
Figure 35:
 
Figure 36:

The second definition option is "case type," as shown in figure 37. In this page, the users can add, edit, delete, and change the activity of the case types. Users can perform the add operation by clicking on the “new record” button and filling out the required fields as shown in the figure 38. An error alert message will also be displayed in case an error occurs while adding or editing the records as shown in the figure 39. As shown in Figure 37, users can also perform the change activity, edit, and delete, as well as filtering by "court office type" and "status" for each case type.
 
Figure 37:
 
Figure 38:
 
Figure 39:
Figure 40 depicts the third definition option, "court office." Users can add, edit, delete, and change the activity of the court offices on this page in the same way that they can on the previous two pages. Figure 41 shows how to add a record by clicking on the "new record" button and filling out the required fields. If an error occurs while adding or editing records, an error alert message will be displayed. As shown in Figure 40 users can also perform the change activity, edit, and delete, as well as filtering by "court office type" and "status" for each court office.

 
Figure 40:
 
Figure 41:

The fourth definition option, "transaction activity subtype," is depicted in Figure 42. On this page, users can add, edit, delete, and change the activity of transaction activities in the same way that they can on the previous three pages. Figure 43 demonstrates how to add a record by clicking the "new record" button and filling out the required fields. An error alert message will be displayed if an error occurs while adding or editing records. Users can also perform the change activity, edit, and delete, as well as filtering by "court office type" and "status" for each transaction activity, as shown in Figure 42.
 
Figure 42:
 
Figure 43:

The fifth definition option, "task type," is depicted in Figure 44. On this page, users can add, edit, delete, and change the activity of task types in the same way that they can on the previous four pages. Figure 45 demonstrates how to add a record by clicking the "new record" button and filling out the required fields. An error alert message will be displayed if an error occurs while adding or editing records.  Users can also perform the change, edit, and delete operations, as well as filtering the list by the "status" for each task type, as shown in Figure 44.

 
Figure 44:
 
Figure 45:

Figure 46 depicts the sixth definition option, "process type." Users can add, edit, delete, and change the activity of task types on this page in the same way they can on the previous five pages. Figure 47 shows how to add a new record through clicking the "new record" button and filling out the necessary fields. If an error occurs while adding or editing records, an error alert message will be displayed. As shown in Figure 46, users can also perform the change, edit, and delete operations, as well as filter the list by the "status" for each process type.
 
Figure 46:
 
Figure 47:

•	Client’s page:
The third option in the sidebar, "clients," as shown in Figure 48, has the properties to display, add, and edit client information as well as change their activity. Figure 49 shows how to perform the add operation by clicking on the "new record" button at the top right corner of the page and filling out the required fields. The user can edit each client by clicking the "edit" button which once clicked, as shown in the figure 50 each record's individual information will be displayed and allow users to edit their records. In case any error occurs will adding or editing the records, an error alert message including the corresponding message will be displayed at the bottom of the modal. Users can also view the clients' detailed information by clicking the arrow icon at the top right of the list. By clicking the icon for the second time, the details will be folded. There is also a switch option that users can use to toggle the status of each client. Finally, the "status" filter operation is integrated into this page.
 
Figure 48:
 
Figure 49:
 
Figure 50:



•	Cases page:
As shown in Figure 51, the fourth option in the sidebar, "cases," has the properties to display, add, and edit client information, as well as uploading files, deleting the case, viewing details, and finally viewing edit history, which is important since the changes created in the cases are extremely critical. Figure 52 shows how to add a record by clicking on the "new record" button in the top right corner of the page and filling out the required fields. The following fields are required to add a case:
1.	Users should select the "court office type," which specifies the court office type of the case being added.
2.	Users should select "role type," which will be modified based on the "court office type" selection and specifies the type of role and is dependent on the type of court office.
3.	The users should select the “clients” which was added in the clients’ section and specifies the related client for the case that is about to be added.
4.	The users should select the "court office" that they defined in the definitions section and specify the court office where the case will be heard.
5.	Users should choose the "case type" that they created in the definitions section to specify the type of case that is about to be added.
6.	Users should choose the "case status" option, which they also defined in the definitions section, to specify the status of the case that is about to be added.
7.	The user should choose the start date of the corresponding case from the date picker.
8.	The user can toggle the check box to indicate whether the end date is known. If the check box is selected, the date picker will appear, allowing customers to select the case's end date.
9.	Similarly, the user will be able to toggle the check box to indicate whether the date has been set.
10.	The users should fill out the case information in a multiline text field.
11.	The user should enter the case number of the case being added.
12.	Finally, to maintain the security of the cases, the user can prevent other users from viewing the case that is about to be added. This is done by clicking the plus icon next to each user in the drop down to hide the case from the selected users. As users are selected, a list of the selected users appears at the bottom of the modal, as shown in Figure 52.
Finally, the user can add a case by clicking the "add!" button, which will update the list of cases so that the user can edit, upload files, delete, view the details, and edit history.
The "edit" option is added as a button for each case, and the other options such as "details," "upload," "history," and "delete" are displayed in a pop over for user convenience, as shown in figure 53. The first option in the pop-over, "details," is displayed as a modal in figure 54, displaying the details of each case. The second option in the pop-over which is “upload” takes the user to a separate page taking the corresponding case’s id as shown in the figure 55 and allows the user to upload a file from their device by clicking the “new record” button on the top right corner of the page and fill out the required areas as well as selecting the related file from their devices as can be seen in the figure 56. After uploading the file, the user can view the details of the file and download it as shown in the figure 55. The third option in the pop-over, "history," takes the user to a separate page that takes the corresponding selected case's id and displays the edit history of the selected case, as shown in figure 57. The modified information in each edit operation is highlighted in yellow to indicate the difference in the modification. The user will be able to scroll through the update history by clicking the left and right arrows on the top right corner of the page. The scroll option is programed in such a way that the scroll to the left will be performed if the length of the scroll is greater than zero and the scroll to the right will be performed if the length of the scroll is greater than or equal to three as the corresponding code of this operation can be seen shown in the figure 58. Lastly, the last option in the pop-over is the delete option which provides the deletion of the cases.
Finally, as with all other pages, there exists the filter option for various properties.

 
Figure 51:
   
Figure 52:                                                                                        Figure 53:                                                                                                           
 
Figure 54:
 
Figure 55:
 
Figure 56: 
 
Figure 57:
 
Figure 58:

•	Transaction Activity page:
As shown in Figure 51, the fifth option in the sidebar, "transaction activities," has the properties to display, add, edit, delete, and view the details of each transaction activity.
Figure 60 depicts how to perform the add operation by clicking on the "new record" button at the top right corner of the page and filling out the required fields such as the "expense," the type of the amount of the transaction activity (which could be "upcoming" which is emphasized with green or "expense" which is emphasized with red), the date of the transaction activity, and so on. The user can edit each client by clicking the "edit" button, which, as shown in figure 59, displays each record's individual information and allows users to edit their records.  If an error occurs while adding or editing records, an error alert message will be displayed at the bottom of the modal, along with the corresponding message. Users can also view detailed information about transaction activities by clicking the arrow icon at the top right of the list and fold the details by clicking the icon a second time. Based on the added transaction activities, the box at the top of the list denotes the "total balance," "total expense," and "total income." Finally, this page incorporates the "transaction activity type" filter operation.

 
Figure 59:
 
Figure 60:

•	Tasks page:
The sixth option in the sidebar, "tasks," as shown in Figure 61, has the properties to display, add, edit, delete, and view the details of each task. Figure 62 shows how to add a record by clicking the "new record" button in the top right corner of the page and filling out the required fields. To add a task, the following fields must be filled out: 
1.	The users should select the “clients” which was added in the clients’ section and specifies the related client for the task that is about to be added.
2.	The users should select the case number which indicates the case related to the task.
3.	The user should select the member involved in the task.
4.	The user should select the “task type” that was added in the “definitions” section to specify the type of the task to be added.
5.	The user should select the “task status” to specify the status of the task that is about to be added.
6.	The user should select the “status” of the task.
7.	The user should insert the information about the specified task.
8.	The user should choose the start date of the specified task from the date picker.
9.	The user can toggle the check box to indicate whether the end date is known. If the check box is selected, the date picker will appear, allowing customers to select the task's end date.
10.	Similarly, the user will be able to toggle the check box to indicate whether the last date has been decided.
Finally, the user can add a task by clicking the "add!" button, which will update the task list so that the user can edit, delete, and view the details, as shown in figure 61. 
The user can edit each client by clicking the "edit" button, which displays the individual information for each record and allows users to edit their records. If an error occurs while adding or editing records, an error alert message with the corresponding message will be displayed at the bottom of the modal, as shown in Figure 63, which shows the incident of adding a task with a client who has no cases. Users can also view detailed information about clients by clicking the arrow icon at the top right of the list. The details will be folded if you click the icon a second time. Users can also toggle the status of each client by using the switch option to provide convenience. Finally, there is a filter operation based on "clients," "users," "status," "task type," and "task status."

 
Figure 61:
 
Figure 62:
 
Figure 63:
•	Events page:
As shown in Figure 64, the sixth option in the sidebar, "tasks," has the properties to display, add, edit, and view the details of each task. Figure 65 shows how to add a record by clicking the "new record" button in the upper right corner of the page and filling out the necessary fields. To add a task, fill out the following fields: 
1.	A “title” for the event.
2.	An “event type” to specify the type of the event.
3.	A “client” to specify the related client to be discussed in the event.
4.	A “case number” to specify the corresponding case that will be discussed in the event.
5.	The “user “that has a participation in the event.
6.	The “status” of the corresponding event.
7.	The “date” the event starts.
8.	The “date” the event ends.
9.	The information about the corresponding event.
Finally, the user can add an event by clicking the "add!" button, which updates the event grid and allows the user to edit and view the details, as shown in figure 64. If an error occurs while adding or editing records, an error alert message will be displayed at the bottom of the modal with the corresponding message. To display the "details" of each event, a modal is opened, as shown in figure 66, which lists the details of the selected events.
 
Figure 64:
 
Figure 65:
 
Figure 66:
•	Messages page:
The last option in the sidebar, "messages," as shown in Figure 67, allows users to send messages via Email and SMS to "clients," "members," or "other people." The user only needs to select the recipient type and one or more recipients before sending the message by selecting the message type, which can be "email" or "SMS" or both. This integration allows lawyers to communicate with their clients or members all in one place, which is critical for staying in touch. As shown in Figure 68, after the user selects multiple recipients, the recipients are listed in a box and can be removed by clicking on the close icon to the right of each recipient, and the message is sent to the recipient(s) by clicking on the "send" button. 
Figure 69 depicts the "post draft" button in the top right corner of the page, which is used in the optional "post draft" option in the "messages" page, that when selected, fills out the title and message text fields with the information from the "post draft" page. There is also a "none" option, which when selected, clears the text fields.  This page includes options for adding, editing, and deleting messages. Figure 70 shows how to add a record by clicking the "new record" button at the top right corner of the page and entering a "title" and a "message." Additionally, edit and delete operations are performed by clicking the "edit" and "delete" buttons on each post draft.
Finally, there is a "sent messages" button in the top right corner that takes users to a page with a list of sent messages and a pagination option, as shown in figure 71.
 
 
 
Figure 67:
 
Figure 68:
 
Figure 69:
 
Figure 70:
 
Figure 71:
Admin Panel:
The admin panel is a panel that only the administrators have access to and displays the total created licences, total users logged into the system, and has an option named “support” to respond to the users that asked questions.
•	Admin dashboard:
Firstly, as can be seen in the figure 72, some necessary statistics are displayed such as “total active liences”, “total active users”, “total balance”, and “total sent messages”.
 
Figure 72:

•	Licences page:
The second option in the sidebar is "licences," which, as shown in figure 73, displays information about each licence with pagination and the ability to filter the licences by "profile name," "email," "users," and "status" by clicking the filter button on the right top corner of the page.
As shown in figure 74, each licence has a detail button that takes the administrator to a page of details with three buttons for "SMS history," "payment history," and "registered users." These options are also depicted in figures 75,76,77, with pagination options for each of them.

 
Figure 73:
 
Figure 74:
 
Figure 75:
 
Figure 76:
 
Figure 77:

•	Users page:
The third option in the sidebar is "users," which, as shown in figure 78, displays information about each user with pagination and the ability to filter the users by "first name," "last name," "cellphone," "status," and "email" by clicking the filter button in the page's right top corner. Each user, as shown in figure 79, has a detail button that takes the administrator to a page of details for the selected user.

 
Figure 78:
 
Figure 79:

•	Admin support page:
The last page in this panel is the "support" page, as shown in Figure 80, where the admin can respond to questions from users and provide service to them. The full name and license name are written in the message field, and notifications are displayed when there is an unread message. In addition, read messages are denoted by a blue tick, whereas unread messages are denoted by a grey tick.
 
Figure 80:








Landing Page:

The hero, as shown in the figure 81 contains the header that when clicked navigates the users to the specified areas and also there exist two buttons that when pressed navigates the users to the MediLaw admin panel.
 
Figure 81:
In the next section, the advantages of this software solution is displayed as can be seen in the figure 82.
 
Figure 82:






Figure 83 displays the feature of MediLaw. 
 
Figure 83:
Figure 84 depicts the information about us.

 
Figure 84:

Figure 85 depicts the contact us form in which the users can send message to us.
 
Figure 85:

Figure 86 depicts the footer, which includes our social media option as well as contact, address, policy, and company information. 
Figure 86:



