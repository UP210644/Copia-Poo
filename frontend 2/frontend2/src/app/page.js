'use client'; 

import React, { useState, useEffect } from "react";
import {
  Container,
  Typography,
  Box,
  Card,
  CardContent,
  TextField,
  Button,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
} from "@mui/material";

const App = () => {
  const [view, setView] = useState("menu");
  const [ticketDescription, setTicketDescription] = useState("");
  const [submitted, setSubmitted] = useState(false);
  const [problemType, setProblemType] = useState("");
  const [equipmentType, setEquipmentType] = useState("");
  const [token, setToken] = useState("your-token-here");
  const [selectedTechnician, setSelectedTechnician] = useState(null);
  const [technicians, setTechnicians] = useState([]);
  const [ticketStatus, setTicketStatus] = useState(null);
  const [tickets, setTickets] = useState([]);

  useEffect(() => {
    const fetchTechnicians = async () => {
      try {
        const response = await fetch("/api/technicians", {
          method: "GET",
          headers: {
            "Authorization": `Bearer ${token}`,
          },
        });

        if (!response.ok) {
          throw new Error("Error al obtener los técnicos");
        }

        const data = await response.json();
        setTechnicians(data);
      } catch (error) {
        console.error("Error al obtener los técnicos:", error);
      }
    };

    fetchTechnicians();
  }, [token]);

  const handleTicketSubmit = async () => {
    const ticketData = {
      description: ticketDescription,
      problemType,
      equipmentType,
      technician: selectedTechnician,
    };

    if (!selectedTechnician) {
      alert("Debe seleccionar un técnico.");
      return;
    }

    const technicianEmail = technicians.find(
      (tech) => tech.name === selectedTechnician
    )?.email;

    if (technicianEmail) {
      const response = await fetch("/api/tickets", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`,
        },
        body: JSON.stringify({
          ...ticketData,
          technicianEmail,
        }),
      });

      if (response.ok) {
        setSubmitted(true);
        setTicketDescription("");
        setProblemType("");
        setEquipmentType("");
        setSelectedTechnician(null);
        setTimeout(() => setSubmitted(false), 3000);
      } else {
        alert("Error al enviar el ticket");
      }
    } else {
      alert("Debe seleccionar un técnico.");
    }
  };

  const fetchTicketStatus = async () => {
    try {
      const response = await fetch("/api/ticket-status", {
        method: "GET",
        headers: {
          "Authorization": `Bearer ${token}`,
        },
      });

      if (response.ok) {
        const data = await response.json();
        setTickets(data); 
      } else {
        throw new Error("Error al obtener el estado del ticket");
      }
    } catch (error) {
      console.error("Error al obtener el estado del ticket:", error);
    }
  };

  const equipmentOptions =
    problemType === "hardware"
      ? ["Servidor", "Computadora", "Impresora", "Proyector"]
      : ["Sistema Operativo", "Aplicación", "Red"];

  const renderMenu = () => (
    <Box
      sx={{
        backgroundImage: `url('https://i.pinimg.com/564x/72/4d/4e/724d4ecf3278fa201b5e41d73c836ff6.jpg')`,
        backgroundSize: "cover",
        backgroundPosition: "center",
        minHeight: "100vh",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        gap: 4,
        padding: 4,
      }}
    >
      <Container
        maxWidth="sm"
        sx={{
          display: "flex",
          justifyContent: "space-around",
          gap: 4,
        }}
      >
        <Card
          sx={{
            width: 200,
            height: 250,
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            alignItems: "center",
            boxShadow: 3,
            cursor: "pointer",
            border: "2px solid #4CAF50",
            borderRadius: "12px",
            "&:hover": {
              boxShadow: 6,
              transform: "scale(1.05)",
              transition: "transform 0.2s",
            },
          }}
          onClick={() => setView("support")}
        >
          <CardContent sx={{ textAlign: "center", padding: 2 }}>
            <Typography variant="h5" color="textPrimary">
              Levantar Ticket
            </Typography>
          </CardContent>
        </Card>

        <Card
          sx={{
            width: 200,
            height: 250,
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            alignItems: "center",
            boxShadow: 3,
            cursor: "pointer",
            border: "2px solid #4CAF50",
            borderRadius: "12px",
            "&:hover": {
              boxShadow: 6,
              transform: "scale(1.05)",
              transition: "transform 0.2s",
            },
          }}
          onClick={() => {
            fetchTicketStatus();
            setView("ticket-status");
          }}
        >
          <CardContent sx={{ textAlign: "center", padding: 2 }}>
            <Typography variant="h5" color="textPrimary">
              Estado del Ticket
            </Typography>
          </CardContent>
        </Card>
      </Container>
    </Box>
  );

  const renderSupportPage = () => (
    <Box
      sx={{
        backgroundImage: `url('https://i.pinimg.com/564x/72/4d/4e/724d4ecf3278fa201b5e41d73c836ff6.jpg')`,
        backgroundSize: "cover",
        backgroundPosition: "center",
        minHeight: "100vh",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        gap: 4,
      }}
    >
      <Container
        maxWidth="sm"
        sx={{
          bgcolor: "white",
          p: 3,
          textAlign: "center",
          boxShadow: 3,
          borderRadius: 2,
          border: "2px solid #4CAF50",
        }}
      >
        <Typography variant="h4" gutterBottom color="textPrimary">
          Soporte Técnico
        </Typography>

        <FormControl fullWidth margin="normal">
          <InputLabel>Tipo de problema</InputLabel>
          <Select
            value={problemType}
            onChange={(e) => setProblemType(e.target.value)}
          >
            <MenuItem value="">
              <em>Seleccionar</em>
            </MenuItem>
            <MenuItem value="hardware">Hardware</MenuItem>
            <MenuItem value="software">Software</MenuItem>
          </Select>
        </FormControl>

        {problemType && (
          <FormControl fullWidth margin="normal">
            <InputLabel>Tipo de equipo</InputLabel>
            <Select
              value={equipmentType}
              onChange={(e) => setEquipmentType(e.target.value)}
            >
              <MenuItem value="">
                <em>Seleccionar</em>
              </MenuItem>
              {equipmentOptions.map((option) => (
                <MenuItem key={option} value={option}>
                  {option}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        )}

        <TextField
          fullWidth
          label="Describe tu problema"
          margin="normal"
          value={ticketDescription}
          onChange={(e) => setTicketDescription(e.target.value)}
        />

        <Typography variant="h6" color="textPrimary" sx={{ mt: 3 }}>
          Selecciona un Técnico
        </Typography>
        <TableContainer component={Paper} sx={{ mt: 2 }}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Nombre</TableCell>
                <TableCell>Especialidad</TableCell>
                <TableCell>Correo Electrónico</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {technicians.map((technician) => (
                <TableRow
                  key={technician.name}
                  onClick={() => setSelectedTechnician(technician.name)}
                  sx={{
                    cursor: "pointer",
                    "&:hover": {
                      backgroundColor: "#f0f0f0",
                    },
                  }}
                >
                  <TableCell>{technician.name}</TableCell>
                  <TableCell>{technician.specialty}</TableCell>
                  <TableCell>{technician.email}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>

        <Button
          fullWidth
          variant="contained"
          sx={{
            mt: 2,
            backgroundColor: "#4CAF50",
            '&:hover': {
              backgroundColor: "#45a049",
            },
          }}
          onClick={handleTicketSubmit}
        >
          {submitted ? "Ticket Enviado" : "Enviar Ticket"}
        </Button>

        <Button
          fullWidth
          variant="contained"
          sx={{
            mt: 2,
            backgroundColor: "#4CAF50",
            '&:hover': {
              backgroundColor: "#45a049",
            },
          }}
          onClick={() => setView("menu")}
        >
          Regresar al Menú
        </Button>
      </Container>
    </Box>
  );

  const renderTicketStatusPage = () => (
    <Box
      sx={{
        backgroundImage: `url('https://i.pinimg.com/564x/72/4d/4e/724d4ecf3278fa201b5e41d73c836ff6.jpg')`,
        backgroundSize: "cover",
        backgroundPosition: "center",
        minHeight: "100vh",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        gap: 4,
      }}
    >
      <Container
        maxWidth="sm"
        sx={{
          bgcolor: "white",
          p: 3,
          textAlign: "center",
          boxShadow: 3,
          borderRadius: 2,
          border: "2px solid #4CAF50",
        }}
      >
        <Typography variant="h4" gutterBottom color="textPrimary">
          Estado de los Tickets
        </Typography>
        <TableContainer component={Paper}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>ID</TableCell>
                <TableCell>Descripción</TableCell>
                <TableCell>Estado</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {tickets.map((ticket) => (
                <TableRow key={ticket.id}>
                  <TableCell>{ticket.id}</TableCell>
                  <TableCell>{ticket.description}</TableCell>
                  <TableCell>{ticket.status}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>

        <Button
          fullWidth
          variant="contained"
          sx={{
            mt: 2,
            backgroundColor: "#4CAF50",
            '&:hover': {
              backgroundColor: "#45a049",
            },
          }}
          onClick={() => setView("menu")}
        >
          Regresar al Menú
        </Button>
      </Container>
    </Box>
  );

  return (
    <div>
      {view === "menu" && renderMenu()}
      {view === "support" && renderSupportPage()}
      {view === "ticket-status" && renderTicketStatusPage()}
    </div>
  );
};

export default App;
