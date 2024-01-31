import './App.css';
import { useState } from "react";


function App() {
    const [input, setInput] = useState("");
    const [output, setOutput] = useState("");

    const handleSubmit = async () => {
        const url = `https://localhost:7121/EmojiPasta`;
        const response = await fetch(url, {
            method: "POST",
            body: JSON.stringify(input),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        });
        await response.json().then(body => setOutput(body));
    }

    return (
        <>
            <h1 id="tabelLabel"> Emoji &#x1F60A; Pasta&nbsp;&#x1F35D; </h1>
            <p> Transform &#x1F98B; text  &#x1F48C; into &#x27A1; lively &#x1F917; emoji &#x1FAF6; narratives! &#x2728; </p>
            <textarea onChange={event => setInput(event.target.value)}></textarea>
            <button onClick={() => handleSubmit()}> Generate Emoji Pasta </button>
            <div className="output">{output}</div>
        </>
    );
}

export default App;