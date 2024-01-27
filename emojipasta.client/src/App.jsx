import './App.css';
import { useState } from "react";


function App() {
    const [input, setInput] = useState("");

    async function EmojiPasta() {
        const response = await fetch('emojipasta');
        const data = await response.json();
    }

    return (
        <>
            <h1 id="tabelLabel"> Emoji &#x1F60A; Pasta&nbsp;&#x1F35D; </h1>
            <p> Transform &#x1F98B; text  &#x1F48C; into &#x27A1; lively &#x1F917; emoji &#x1FAF6; narratives! &#x2728; </p>

            <textarea onChange={event => setInput(event.target.value)}></textarea>
            <button> Generate Emoji Pasta </button>
        </>
    );
}

export default App;