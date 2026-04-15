import './App.css';
import { HiSparkles } from 'react-icons/hi';
import { useState } from 'react';
import ReportForm from './components/ReportForm';
import ReportOutput from './components/ReportOutput';

function App() {
    const [notes, setNotes] = useState("");
    const [report, setReport] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const [selectedTemplate, setSelectedTemplate] = useState('Detailed Report');

    const generateReport = async () => {
        if (!notes.trim()) return;
        setIsLoading(true);
        try {
            const res = await fetch('http://localhost:5183/api/report', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ Notes: notes })
            });
            const data = await res.json();
            setReport(data.generatedReport);
        } catch (err) {
            console.error(err);
            setReport(`Error: ${err.message}`);
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div>
            <div id="header">
                <h1>
                    <HiSparkles style={{ color: "#6C63FF", marginRight: "8px" }} />
                    Daily Standup Assistant
                </h1>
            </div>

            <div style={{ display: "flex", gap: "20px" }}>
                <ReportForm
                    notes={notes}
                    setNotes={setNotes}
                    handleGenerate={generateReport}
                    selectedTemplate={selectedTemplate}
                    setSelectedTemplate={setSelectedTemplate}
                    isLoading={isLoading}
                />
                <ReportOutput report={report} />
            </div>
        </div>
    );
}

export default App;
