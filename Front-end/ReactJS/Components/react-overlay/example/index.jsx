import React, { useState } from "react";
import { createRoot } from 'react-dom/client';
import Overlay from "../src/Overlay";

export const App = () => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <>
      <h1>Example Overlay:</h1>
      <div className="container">
        <button onClick={() => setIsOpen(true)}>Click to Open List</button>
        <Overlay isOpening={isOpen} onClose={() => setIsOpen(false)}>
          <>
            <div>Overlay Item 1</div>
            <div>Overlay Item 2</div>
            <div>Overlay Item 3</div>
            <div>Overlay Item 4</div>
            <div>Overlay Item 5</div>
          </>
        </Overlay>
        <div>Background Item 1</div>
        <div>Background Item 2</div>
        <div>Background Item 3</div>
      </div>
    </>
  );
};

const root = createRoot(document.getElementById('root'));
root.render(
    <React.Fragment>
        <App />
    </React.Fragment>
);
