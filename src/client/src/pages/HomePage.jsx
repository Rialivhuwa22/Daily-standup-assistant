import React from 'react';
import { useReportGenerator } from '../hooks/useReportGenerator';
import ReportForm from '../components/ReportForm';
import ReportOutput from '../components/ReportOutput';
import { FaRegClock, FaFileAlt } from 'react-icons/fa';
import { FaWandMagicSparkles } from "react-icons/fa6";



export function HomePage() {
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
                <h1>
                    Daily Standup Assistant
                </h1>
                <p className="subtitle">
                    Transform your messy daily notes into professional standup reports. Just write what
                    you did, and we'll format it perfectly.
                </p>
                <div className="header-tags">
                    <span className="tag">
                        <FaRegClock /> Saves time
                    </span>
                    <span className="tag">
                        <FaFileAlt /> Professional format
                    </span>
                    <span className="tag">
                        <FaWandMagicSparkles /> AI-powered
                    </span>
                </div>
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