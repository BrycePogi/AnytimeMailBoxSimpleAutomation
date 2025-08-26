Anytime Mailbox – QA Automation Engineer Assessment
This repository contains my solution for the QA Automation Engineer Assessment for Anytime Mailbox.

Project Overview
The goal of this project is to demonstrate my skills in test automation using Selenium WebDriver with C# and NUnit, focusing on:
Creating maintainable automation using the Page Object Model (POM) pattern.
Handling UI automation including search functionality and login workflows.
Implementing explicit waits for stable interaction with dynamic elements.
Demonstrating handling of iframe-based reCAPTCHA by waiting for its visibility.

🧪 Test Scenarios Implemented

Search – Success Case ✅
Enter a valid city/address and verify that results are returned.
Search – No Results Case ❌
Enter an invalid city/address and verify that no results are returned.

Login – Invalid Credentials 🔐
Attempt login with invalid credentials and validate error message.
reCAPTCHA Handling 🔄
Wait until reCAPTCHA iframe and checkbox are displayed before attempting login.

🛠️ Tech Stack
Language: C#
Framework: NUnit
Automation Tool: Selenium WebDriver
IDE: Visual Studio Code
Build Tool: .NET CLI (dotnet test)

📂 Project Structure
AnytimeMailboxTests/
 ├── Pages/         # Page Object Model classes
 │    ├── LoginPage.cs
 │    └── SearchPage.cs
 ├── Tests/         # NUnit test classes
 │    ├── LoginTests.cs
 │    └── SearchTests.cs
 ├── AnytimeMailboxTests.csproj
 └── README.md

▶️ How to Run

Clone the repository:

git clone https://github.com/<your-username>/anytime-mailbox-automation.git
cd anytime-mailbox-automation
Restore dependencies:
dotnet restore
Run tests:
dotnet test

Sample Test on Local:
<img width="1608" height="690" alt="image" src="https://github.com/user-attachments/assets/a28534ff-ebca-4d1a-a5e7-764e63ce82bc" />


⚡ Notes
reCAPTCHA is designed to block automation; in this solution, the script detects and waits for the reCAPTCHA iframe and checkbox as part of the login flow.
Tests are structured to show automation strategy and framework usage, even though solving the captcha itself is outside the scope of automation.

This project highlights my skills in C#, Selenium, NUnit, and POM best practices.

✨ Developed with passion for quality engineering by Bryce Loyola
