"use client";

import React, { useState } from "react";
import { Container, Typography, Button, Box, TextField, CircularProgress } from "@mui/material";
import { createTheme, ThemeProvider } from "@mui/material/styles";

const theme = createTheme({
  palette: {
    background: {
      default: "#f5f5f5",
    },
    primary: {
      main: "#90caf9",
    },
    text: {
      primary: "#333",
    },
  },
});

function App() {
  const [employeeNumber, setEmployeeNumber] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);

  const handleLogin = async () => {

    setLoading(true);
    try {
      const response = await fetch("/api/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ employeeNumber, password }),
      });

      const data = await response.json();
      setLoading(false);

      if (response.ok) {
        window.location.href = `/dashboard?token=${data.token}`;
      } else {
        setError(data.message || "No se pudo iniciar sesión. Inténtalo de nuevo.");
      }
    } catch (err) {
      setLoading(false);
      setError("No se pudo conectar al servidor.");
    }
  };

  return (
    <ThemeProvider theme={theme}>
      <Box
        sx={{
          backgroundImage: `url('https://i.pinimg.com/564x/72/4d/4e/724d4ecf3278fa201b5e41d73c836ff6.jpg')`,
          backgroundSize: "cover",
          backgroundPosition: "center",
          minHeight: "100vh",
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <Container
          maxWidth="sm"
          sx={{
            bgcolor: "background.default",
            p: 4,
            borderRadius: 2,
            textAlign: "center",
            boxShadow: 3,
          }}
        >
          <Typography variant="h4" color="textPrimary" gutterBottom>
            Soporte técnico
          </Typography>
          <Typography variant="body1" color="textSecondary" gutterBottom>
            Ingresa los siguientes datos para acceder.
          </Typography>
          <Box mt={2}>
            <TextField
              fullWidth
              label="Número de nómina"
              variant="outlined"
              margin="normal"
              value={employeeNumber}
              onChange={(e) => setEmployeeNumber(e.target.value)}
              error={!!error}
              helperText={error && "Por favor, revisa los datos ingresados."}
            />
            <TextField
              fullWidth
              label="Contraseña"
              type="password"
              variant="outlined"
              margin="normal"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              error={!!error}
            />
          </Box>
          <Box mt={3}>
            <Button
              variant="contained"
              color="primary"
              onClick={handleLogin}
              disabled={loading}
              startIcon={loading && <CircularProgress size={20} />}
            >
              {loading ? "Procesando..." : "Ingresar"}
            </Button>
          </Box>
        </Container>
      </Box>
    </ThemeProvider>
  );
}

export default App;