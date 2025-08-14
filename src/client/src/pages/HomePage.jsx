import React from 'react';
// --- 1. Import our new custom hook ---
import { useReportGenerator } from '../hooks/useReportGenerator';

import ReportForm from '../components/ReportForm';
import ReportOutput from '../components/ReportOutput';

//import { FaRegClock, FaFileAlt, FaRobot } from 'react-icons/fa';

export function HomePage() {
    // --- 2. Call the hook to get all state and logic ---
    const {
        notes,
        setNotes,
        report,
        selectedTemplate,
        setSelectedTemplate,
        isLoading,
        error,
        handleGenerate,
    } = useReportGenerator();

    return (
        <>
            <div className="app-header">
                <h1>{'\u2728'} Daily Standup Assistant</h1>
                <p>Transform your messy daily notes into professional standup reports. Just write what you did, and we'll format it perfectly.</p>
            </div>

            <div className="app-container">
                <ReportForm
                    notes={notes}
                    setNotes={setNotes}
                    handleGenerate={handleGenerate}
                    selectedTemplate={selectedTemplate}
                    setSelectedTemplate={setSelectedTemplate}
                    isLoading={isLoading}
                />
                {error && <div className="error-message">{error}</div>}
                <ReportOutput report={report} selectedTemplate={selectedTemplate} />
            </div>
        </>
    );
}