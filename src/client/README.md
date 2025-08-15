# Daily Standup Assistant

A web application that helps developers quickly turn messy daily notes into professional, structured standup reports using AI-powered paraphrasing.

---

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [API](#api)
- [Contributing](#contributing)
- [License](#license)

---


## Features
- Paraphrase daily notes into a professional paragraph.
- Generate structured **Problem, Action, Result** sections.
- AI-powered summarization using **OpenAI Chat API**.
- Download reports as PDF.
- Supports short or even minimal notes like `"nothing"`.

---

## Tech Stack

### Frontend
- **React.js** – UI library for building interactive components.
- **React Icons** – for displaying icons in the UI.
- **TailwindCSS / Custom CSS** – for styling components.
- **jsPDF** – for generating downloadable PDF reports.

### Backend
- **ASP.NET Core Web API (C#)** – serves the report generation endpoint.
- **OpenAI .NET SDK** – connects to OpenAI’s API for paraphrasing.
- **Dependency Injection** – to manage services cleanly.

### API
- **POST `/api/report`** – accepts user notes and returns:
  ```json
  {
    "paragraph": "Expanded, professional version of notes.",
    "problem": "Problem section extracted from notes.",
    "action": "Action section extracted from notes.",
    "result": "Result section extracted from notes."
  }
Handles short notes, blank input, or "nothing" to always return a meaningful report.

Getting Started
Prerequisites
Node.js (v18+)

.NET SDK (v7+)

An OpenAI API key

Frontend
bash
Copy
Edit
cd src/client
npm install
npm start
Backend
bash
Copy
Edit
cd src/server
dotnet restore
dotnet run
Usage
Open the app in your browser (usually http://localhost:3000).

Write your daily notes in the textarea (short notes).

Click Generate Report.

View the generated paragraph and structured Problem, Action, Result.

Download the report as PDF if needed.

Contributing
Fork the repository.

Create a new branch: git checkout -b feature/your-feature

Make your changes.

Commit: git commit -m 'Add some feature'

Push: git push origin feature/your-feature

Open a pull request.

