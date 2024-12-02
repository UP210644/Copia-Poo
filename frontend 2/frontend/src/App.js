import React from 'react';
import AppTheme from './shared-theme/AppTheme';
import ColorModeSelect from './shared-theme/ColorModeSelect';
import SignIn from './sign-in/SignIn'; 

function App() {
  return (
    <AppTheme>
      <div className="App">
        <header className="App-header">
          <ColorModeSelect />
          <SignIn />
        </header>
      </div>
    </AppTheme>
  );
}

export default App;
