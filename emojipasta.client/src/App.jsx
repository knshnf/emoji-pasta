import './App.css';

function App() {
    return (
        <div>
            <h1 id="tabelLabel">Emoji Pasta &#x1F35D;</h1>
            <p> Transform text into lively emoji narratives! &#x1F35D;&#x2728;</p>
        </div>
    );

    async function EmojiPasta() {
        const response = await fetch('emojipasta');
        const data = await response.json();
    }
}

export default App;